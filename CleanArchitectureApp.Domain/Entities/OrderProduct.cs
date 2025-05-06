using CleanArchitectureApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Domain.Entities
{
    public class OrderProduct : AuditableEntity
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        public Order? Order { get; private set; }
        public Product? Product { get; private set; }

        [SetsRequiredMembers]
        public OrderProduct(Guid orderId, Guid productId, int quantity, decimal unitPrice)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }

}
