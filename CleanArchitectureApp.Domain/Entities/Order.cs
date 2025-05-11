namespace CleanArchitectureApp.Domain.Entities
{
    public class Order : BaseEntity<Guid>
    {
        public Guid CustomerId { get; private set; }
        public DateTime OrderDate { get; private set; }

        public decimal TotalAmount => OrderProducts.Sum(i => i.Quantity * i.UnitPrice);

        public Customer? Customer { get; private set; }
       
        public ICollection<OrderProduct> OrderProducts { get; set; } = [];

        [SetsRequiredMembers]
        public Order(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
            OrderDate = DateTime.UtcNow;
        }

        public Order()
        {
            CustomerId = Guid.NewGuid();
        }

        public void AddItem(Guid productId, int quantity, decimal unitPrice)
        {
            var item = new OrderProduct( Id, productId, quantity, unitPrice);

            OrderProducts.Add(item);
        }
    }
}
