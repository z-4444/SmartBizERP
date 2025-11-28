using SmartBiz.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartBiz.Core.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required Guid UserId { get; set; }

        public decimal TotalAmount { get; set; } = decimal.Zero;

        public OrderStatus Status { get; set; } = OrderStatus.Pending; // e.g., "Pending", "Approved", "Shipped"

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        // Navigation
        public User User { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
