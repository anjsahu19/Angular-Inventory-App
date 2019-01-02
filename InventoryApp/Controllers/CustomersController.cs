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
using System.Web;
using System.Web.Http;

namespace InventoryApp.Controllers
{
  public class CustomersController : ApiController
  {

    // GET api/<controller>
    public List<Customer> Get()
    {
      List<Customer> customers = new List<Customer>();
      using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryApp"].ConnectionString))
      {
        customers = db.Query<Customer>("select * from Customer").ToList();
      }
      return customers;
    }

    // GET api/<controller>/5
    public Customer Get(int id)
    {
      Customer customer = new Customer();
      using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryApp"].ConnectionString))
      {
        customer = db.Query<Customer>(string.Format("select * from Customer Where Id={0}", id), new { id }).SingleOrDefault();
      }

      return customer;
    }

    // POST api/<controller>
    public IHttpActionResult Post(Customer customer)
    {
      int rowsInserted = 0;
      using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryApp"].ConnectionString))
      {
        string InsertQuery = String.Format("Insert into Customer values('{0}','{1}','{2}','{3}','{4}')",
          customer.FirstName,
          customer.LastName,
          customer.City,
          customer.Country,
          customer.Phone);

        rowsInserted = db.Execute(InsertQuery);
      }

      if (rowsInserted == 0)
        return NotFound();
      else
        return Ok("New Customer Inserted");
    }

    // PUT api/<controller>/5
    public IHttpActionResult Put(int id, Customer customer)
    {
      int rowsUpdated = 0;
      using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryApp"].ConnectionString))
      {
        string updateQuery = string.Format("UPDATE Customer SET FirstName='{0}',LastName='{1}',City='{2}',Country='{3}',Phone='{4}' where Id={5}",
          customer.FirstName,
          customer.LastName,
          customer.City,
          customer.Country,
          customer.Phone,
          id);

        rowsUpdated = db.Execute(updateQuery);

        if (rowsUpdated == 0)
          return NotFound();
        else
          return Ok("Customer Details Updated!");

      }
    }

    // DELETE api/<controller>/5
    public IHttpActionResult Delete(int id)
    {
      int rowsDeleted = 0;
      using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryApp"].ConnectionString))
      {
        string DeleteQuery = string.Format("Delete from Customer where Id={0}", id);
        rowsDeleted = db.Execute(DeleteQuery, new { Id = id });
      }
      if (rowsDeleted > 0)
        return NotFound();

      else
        return Ok(string.Format("Customer With Id {0} deleted..", id));
    }


  }
}
