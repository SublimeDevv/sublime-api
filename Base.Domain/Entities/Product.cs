namespace Base.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public decimal Price { get; private set; }
        public string Description { get; private set; } = null!;

        public Product(string name, decimal price, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product name cannot be null or empty.", nameof(name));
            }
            
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative.", nameof(price));
            }
            
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));
            }

            Id = Guid.CreateVersion7();
            Name = name;
            Price = price;
            Description = description;
        }
    }
}
