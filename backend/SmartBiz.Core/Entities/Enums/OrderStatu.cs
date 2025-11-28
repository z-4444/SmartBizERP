using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SmartBiz.Core.Entities.Enums
{
    public enum OrderStatus
    {
        [Description("Pending")] // For UI display
        Pending = 1,

        [Description("Approved")]
        Approved = 2,

        [Description("Shipped")]
        Shipped = 3,

        [Description("Delivered")]
        Delivered = 4,

        [Description("Cancelled")]
        Cancelled = 5
    }
}
