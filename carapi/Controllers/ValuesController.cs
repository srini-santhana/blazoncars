using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using carapi.Models;
using System.Data;

namespace carapi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public  List<car> Get()
        {
            List<car> result = new List<car>();

            using (SqlConnection conn = new SqlConnection(AppHelpers.carconn))
            {
                SqlCommand cmd = new SqlCommand("ip_getcars");
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
 
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        result.Add(
                            new car
                            {
                                CarId=  Int32.Parse(reader[0].ToString()),
                                CarDesc = reader[1].ToString()
                            });
                }
                conn.Close();
            }

            return result;
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}