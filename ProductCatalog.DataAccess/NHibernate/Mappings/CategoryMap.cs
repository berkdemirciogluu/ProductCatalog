using FluentNHibernate.Mapping;
using ProductCatalog.Entities.Concrete;

namespace ProductCatalog.DataAccess.NHibernate.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("category");

            Id(x => x.Id)
                .GeneratedBy.Identity();

            Map(b => b.CategoryName)
                .Not.Nullable();
        }
    }
}
