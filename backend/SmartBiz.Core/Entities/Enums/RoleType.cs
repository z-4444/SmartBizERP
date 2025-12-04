using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SmartBiz.Core.Entities.Enums
{
    public enum RoleType
    {
        [Description("Customer")]
        Customer = 1,

        [Description("Staff")]
        Staff = 2,

        [Description("Manager")] 
        Manager = 3,

        [Description("Admin")]
        Admin = 4
    }
}
