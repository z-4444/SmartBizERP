using System;
using System.Collections.Generic;
using System.Text;

namespace SmartBiz.Core.Entities
{
    public class Inventory
    {
        public int Id { get; set; }

        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public Product? Product { get; set; }    // Navigation
    }
}
