using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryApp.Models
{
  public class Product
  {
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int  SupplierId { get; set; }
    public double UnitPrice { get; set; }
    public string Package { get; set; }
    public bool IsDiscontinued { get; set; }
    public Supplier SupplierObj { get; set; }
  }
}
