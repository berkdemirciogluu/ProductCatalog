﻿using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Core.CrossCuttingConcerns.Caching;
using ProductCatalog.Core.Utilities.Interceptors;
using ProductCatalog.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        // Tetiklenen methodu Namespace'i ismi ve parametrelerine göre "key" oluşturuyor.
        // Eğer key daha önce oluşturulmuşsa onu kullanır. Yoksa verileri veri tabanından cache aktarır. 
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
