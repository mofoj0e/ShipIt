namespace Closure.ECommerceShipping.Api.Application.Products.Models
{
    public class ProductAddDto
    {
        public string Name { get; set; }
        public int InventoryQuantity { get; set; }
        public bool ShipOnWeekends { get; set; }
        public int MaxBusinessDaysToShip { get; set; }
        public string ImageUrl { get; set; }
    }
}