using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Core.Utilities.IoC;
using System.Text.RegularExpressions;

namespace ProductCatalog.Core.CrossCuttingConcerns.Caching.Microsoft
{
    //Microsoftta bu kodların hali hazırda olmasınakarşılık bu class altında bu kodlar  toplandı. İlerleyen zamanlarda farklı bir teknoloji kullanılması ihtimaline karşılık ayrı bir classda yazıldı.
    //Var olan sistemi kendi sistemimize uyarlamak için. Buna Adapter pattern uygulandı.
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        //Cache oluştuma methodu
        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key,value,TimeSpan.FromSeconds(duration));
        }

        //Memory Cacheden getleme
        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        //Bellekte cache in olup olmadığını döndürür
        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key,out _); //Bellekte cache olup olmadığına bakar. Değer döndürmek istemediğimiz için bu şekide kullandık.
        }

        public void Remove(string key)
        {
            _memoryCache?.Remove(key);
        }

        //Belirli bir patterne göre çalışma anında cache i uçurmak için yazıldı. 
        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
