using FluentNHibernate.Mapping;
using ProductCatalog.Entities.Concrete;

namespace ProductCatalog.DataAccess.NHibernate.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("tblcategory");

            Id(x => x.Id);
            //HasOne(x => x.Product).Constrained().Cascade.None();

            Map(b => b.CategoryName)
                .Not.Nullable();
        }
    }
}
