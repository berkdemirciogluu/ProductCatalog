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
            Table("product");

            Id(x => x.Id);

            Map(b => b.UserId)
                .Not.Nullable();

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

            HasMany(x => x.Offers);

            HasMany(x => x.Users);

            Map(b => b.IsDeleted)
                .Not.Nullable();

            Map(b => b.CreatedDate)
                .Not.Nullable();

        }
    }
}
