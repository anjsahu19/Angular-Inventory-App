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
  public class OrdersController : ApiController
  {
    // GET api/<controller>
    public List<Order> Get()
    {
      List<Order> orders = new List<Order>();
      using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryApp"].ConnectionString))
      {
        string query = "Select o.Id, o.OrderNumber, o.OrderDate,o.TotalAmount , c.Firstname+' '+c.Lastname 'CustomerName',o.CustomerId from [Anj_TestDB].[dbo].[Order] o join [Anj_TestDB].[dbo].[Customer] c on o.CustomerId=c.Id;";
        orders = db.Query<Order>(query).ToList();
      }
      return orders;
    }

    // GET api/<controller>/5
    public string Get(int id)
    {
      return "value";
    }

    // POST api/<controller>
    public void Post([FromBody]string value)
    {
    }

    // PUT api/<controller>/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
    }
  }
}
