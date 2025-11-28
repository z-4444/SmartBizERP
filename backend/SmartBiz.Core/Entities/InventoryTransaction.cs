using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartBiz.Core.Entities
{
    public class InventoryTransaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required Guid ProductId { get; set; }

        public Guid? UserId { get; set; } // Who performed (e.g., Staff restocking)

        public int QuantityChange { get; set; } =0;

        public string Type { get; set; } = "Restock"; // e.g., "Restock", "Sale", "Adjustment"

        [MaxLength(200)]
        public string Notes { get; set; } = string.Empty;

        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        // Navigation
        public Product Product { get; set; } = null!;
        public User? User { get; set; }
    }
}
