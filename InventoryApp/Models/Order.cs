using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public string CustomerName { get; set; }
  }
}
