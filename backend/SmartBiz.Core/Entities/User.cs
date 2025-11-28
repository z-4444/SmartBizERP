using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace SmartBiz.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(100)]
        public required string FullName { get; set; }

        [MaxLength(100)]
        public required string Username { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        public required string PasswordHash { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; } =string.Empty;

        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        public Guid RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<Order> Orders { get; set; } = new List<Order>(); // For customers/staff placing orders
        public ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>(); // For staff managing stock
    }
}
