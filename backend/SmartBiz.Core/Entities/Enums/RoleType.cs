using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SmartBiz.Core.Entities.Enums
{
    public enum RoleType
    {
        [Description("Customer")] // Limited access: view/place orders
        Customer = 1,

        [Description("Staff")] // Process orders, update inventory
        Staff = 2,

        [Description("Manager")] // Approve orders, view reports
        Manager = 3,

        [Description("Admin")] // Full access: manage users, products
        Admin = 4
    }
}
