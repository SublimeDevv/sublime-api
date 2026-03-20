namespace Base.Application.DTOs.Products
{
    public class ProductDetailDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
    }
}