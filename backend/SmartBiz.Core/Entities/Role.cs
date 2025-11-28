using SmartBiz.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartBiz.Core.Entities
{
    public class Role
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required RoleType RoleName { get; set; } = RoleType.Customer;  // "Admin", "Manager", "Staff", "Customer"

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty; // e.g., "Full access for owners"

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
