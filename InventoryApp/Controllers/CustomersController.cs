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