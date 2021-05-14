namespace Closure.ECommerceShipping.Api.Application.Common
{
    public static class Constants
    {
        public static string OrderDate = "OrderDate";

        public static class ValidationMessages
        {
            public static string ProductNameRequired = "Product Name is required.";
            public static string ProductQuantityRequired = "Product InventoryQuantity should be greater than zero.";
            public static string ProductMaxBusinessDaysToShipRequired = "Product MaxBusinessDaysToShip should be greater than zero.";
        }
    }
}
