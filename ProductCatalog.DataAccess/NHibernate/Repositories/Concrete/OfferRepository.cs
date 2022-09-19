using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using ProductCatalog.DataAccess.NHibernate.Repositories.Base;
using ProductCatalog.Entities.Concrete;
using ProductCatalog.Entities.DTOs.Offer;
using ProductCatalog.Entities.DTOs.Product;

namespace ProductCatalog.DataAccess.NHibernate.Repositories.Concrete
{
    public class OfferRepository : HibernateRepository<Offer>, IOfferRepository
    {

        ICategoryRepository _categoryRepository;
        IProductRepository _productRepository;
        IUserRepository _userRepository;

        public OfferRepository(ICategoryRepository categoryRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public List<GetUserOfferDto> GetUserOfferedProducts(string userId)
        {
            var result = (from offer in Entities
                         join product in _productRepository.Entities on offer.ProductId equals product.Id
                         join category in _categoryRepository.Entities on product.CategoryId equals category.Id
                         where product.UserId == Convert.ToInt32(userId) && offer.IsDeleted == false
                          select new GetUserOfferDto()
                         {
                             Id = offer.Id,
                             OfferedPrice = offer.OfferedPrice,
                             IsApproved = offer.IsApproved,
                             Product = new GetUserProductsDto
                             {
                                 Id = product.Id,
                                 ProductName = product.ProductName,
                                 Description = product.Description,
                                 ColorName = product.Color,
                                 BrandName = product.Brand,
                                 Price = product.Price,
                             },

                         }).ToList();

            return result;
        }

        public List<GetUserOfferDto> GetUserOffers(string userId)
        {
            var result = (from offer in Entities
                         join product in _productRepository.Entities on offer.ProductId equals product.Id
                         join category in _categoryRepository.Entities on product.CategoryId equals category.Id
                         join user in _userRepository.Entities on offer.UserId equals user.Id
                         where offer.UserId == Convert.ToInt32(userId) && offer.IsDeleted == false && user.IsDeleted == false
                         select new GetUserOfferDto
                         {
                             Id = offer.Id,
                             Product = new GetUserProductsDto
                             {
                                 Id = product.Id,
                                 ProductName = product.ProductName,
                                 Description = product.Description,
                                 ColorName = product.Color,
                                 BrandName = product.Brand,
                                 Price = product.Price,
                             },
                             OfferedPrice = offer.OfferedPrice,
                             IsApproved = offer.IsApproved,
                         }).ToList();

            return result;
        }
    }
}
