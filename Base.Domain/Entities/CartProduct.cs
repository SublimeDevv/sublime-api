namespace Base.Domain.Entities
{
    public class CartProduct
    {
        public Guid Id { get; private set; }
        public Guid CartId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public Cart? Cart { get; private set; }
        public Product? Product { get; private set; }
    }
}
