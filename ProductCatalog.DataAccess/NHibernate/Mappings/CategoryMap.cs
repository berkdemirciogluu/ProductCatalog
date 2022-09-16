using FluentNHibernate.Mapping;
using ProductCatalog.Entities.Concrete;

namespace ProductCatalog.DataAccess.NHibernate.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("category");

            Id(x => x.Id);

            Map(b => b.CategoryName)
                .Not.Nullable();

            Map(b => b.IsDeleted)
                .Not.Nullable();

            Map(b => b.CreatedDate)
                .Not.Nullable();
        }
    }
}
