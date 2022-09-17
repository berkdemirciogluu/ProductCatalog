namespace ProductCatalog.Business.Constants
{
    public static class Messages
    { 
        public static string CategoryAdded = "Category is added";
        public static string CategoryNotAdded = "Category could not be added";
        public static string CategoryInvalid = "Category is invalid";
        public static string CategoryDeleted = "Category is deleted";
        public static string CategoryNotDeleted = "Category could not be deleted";
        public static string CategoryListed = "Categories are listed";
        public static string CategoryUpdated = "Category is updated";
        public static string CategoryNotUpdated = "Category could not be updated";

        public static string ProductInvalid { get; internal set; }
        public static string ProductDeleted { get; internal set; }
        public static string ProductNotDeleted { get; internal set; }
        public static string CategoryNameWarning { get; internal set; }
        public static string CategoryNameAlreadyExists { get; internal set; }
    }
}
