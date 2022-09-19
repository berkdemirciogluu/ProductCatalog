using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using ProductCatalog.Entities.Concrete;
using FluentNHibernate.Mapping;

namespace ProductCatalog.DataAccess.NHibernate.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("tblproduct");

            Id(b => b.Id);

            Map(b => b.CategoryId);

            Map(b => b.UserId);

            Map(b => b.OfferId);

            Map(b => b.ProductName)
                .Not.Nullable();

            Map(b => b.Description)
                .Not.Nullable();

            Map(b => b.IsOfferable)
                .Not.Nullable();

            Map(b => b.IsSold)
                .Not.Nullable();            

            Map(b => b.Color)
                .Not.Nullable();

            Map(b => b.Brand)
                .Not.Nullable();

            Map(b => b.Price)
                .Not.Nullable();
            Map(b => b.IsDeleted);
        }
    }
}
