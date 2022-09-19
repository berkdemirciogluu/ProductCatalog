using ProductCatalog.Entities.DTOs.Offer;
using ProductCatalog.Entities.DTOs.Product;
using System.Runtime.Serialization;

namespace ProductCatalog.Business.Constants
{
    public static class Messages
    {
        public static string AuthorizationDenied = "Authorization Denied";
        public static string CategoryAdded = "Category is added";
        public static string CategoryNotAdded = "Category could not be added";
        public static string CategoryInvalid = "Category is invalid";
        public static string CategoryDeleted = "Category is deleted";
        public static string CategoryNotDeleted = "Category could not be deleted";
        public static string CategoryListed = "Categories are listed";
        public static string CategoryUpdated = "Category is updated";
        public static string CategoryNotUpdated = "Category could not be updated";
        public static string ProductInvalid = "Product is invalid";
        public static string ProductDeleted = "Product is deleted";
        public static string ProductNotDeleted = "Product could not be deleted";
        public static string CategoryNameAlreadyExists = "Category name already exist";
        public static string LoginWarning = "Wrong Username or Password.";
        public static string SuccesfulLogin = "Wrong Username or Password.";
        public static string UserRegistered = "Wrong Username or Password.";
        public static string TokenGenerated = "Token Generated";

        public static string ProductAdded = "Product is Added.";

        public static string ProductUpdated = "Product is updated.";

        public static string NotProductOwner = "You do not own this product.";

        public static string UserInvalid = "User invalid.";

        public static string ProductsListed = "Products listed.";

        public static string ProductNotSaled = "Product is not on sale.";

        public static string OfferAccepted = "Offer is accepted.";

        public static string OfferInvalid = "Offer is invalid.";

        public static string OfferDeleted = "Offer is deleted.";

        public static string OfferUpdated = "Offer updated.";

        public static string OfferApproved = "Offer is approved.";

        public static string NotOfferOwner = "You do not have this offer record. Please check offer id.";

        public static string OffersListed = "Offers are listed.";

        public static string ProductSold = "Product is sold.";

        public static string OfferCannotWitdrawn = "Offer has been already approved. You cannot withdraw your off back.";

        public static string OfferWithdrawn = "Offer is withdrawn.";

        public static string NoUserOffer = "You do not have any offer record";

        public static string NoUserProductOffer = "There is no any offer to your product.";
    }
}
