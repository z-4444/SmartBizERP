using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartBiz.Core.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(200)]
        public required string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public required decimal Price { get; set; }

        public int StockQuantity { get; set; } = 0;

        [MaxLength(100)]
        public string SKU { get; set; } = string.Empty ;

        [MaxLength(50)]
        public string Category { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        [MaxLength(500)]
        public string ImageUrl { get; set; } = string.Empty;

        // Navigation
        public Inventory? Inventory { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();
    }
}
