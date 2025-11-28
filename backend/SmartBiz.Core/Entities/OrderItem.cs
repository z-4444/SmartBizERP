using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartBiz.Core.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required Guid OrderId { get; set; }

        public required Guid ProductId { get; set; }

        public int Quantity { get; set; } = 0;

        public decimal UnitPrice { get; set; }=decimal.Zero;

        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
