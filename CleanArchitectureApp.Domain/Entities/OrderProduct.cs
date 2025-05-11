namespace CleanArchitectureApp.Domain.Entities
{
    [method: SetsRequiredMembers]
    public class OrderProduct(Guid orderId, Guid productId, int quantity, decimal unitPrice) : AuditableEntity
    {
        public Guid OrderId { get; private set; } = orderId;
        public Guid ProductId { get; private set; } = productId;
        public int Quantity { get; private set; } = quantity;
        public decimal UnitPrice { get; private set; } = unitPrice;

        public Order? Order { get; private set; }
        public Product? Product { get; private set; }
    }
}
