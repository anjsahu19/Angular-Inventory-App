using Dapper;
using InventoryApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryApp.Controllers
{
  public class ProductController : ApiController
  {

    public IHttpActionResult Get()
    {
      List<Product> products = new List<Product>();
      using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryApp"].ConnectionString))
      {
        products = db.Query<Product, Supplier, Product>("select p.Id, p.ProductName, p.UnitPrice,p.Package,p.IsDiscontinued, p.SupplierId,s.Id, s.CompanyName, s.ContactName, s.ContactTitle, s.City, s.Country, s.Phone, s.Fax " +
                                      "from Product p join Supplier s on p.SupplierId=s.Id;",(product,supplier)=> {
                                        product.SupplierObj = supplier;
                                        return product;
                                      },splitOn: "SupplierId").Distinct().ToList();       
      }
      if (products.Count > 0)
        return Ok(products);
      else
        return NotFound();
    }

    



  }
}
