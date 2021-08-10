using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using Nest;
using System.Collections;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Data.Sql;
using System.Net.Http;
using System.Web.Http.Cors;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    [Route("api/valuescontroller")]
    [ApiController]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ControllerBase
    { 
        
        // GET: api/<ValuesController>
        [HttpGet]
       
        public IEnumerable<value> Get()

        {
            SqlConnection sqlconn = new SqlConnection(@"Data Source=DESKTOP-FQMAG4V; Initial Catalog=employesdetail;User=sa;password=ayush@123");
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM studentdetails", sqlconn);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            List<value> studentdatas = new List<value>();

            foreach (DataRow row in dtbl.Rows)
            {
                value student = new value();
                student.id = Convert.ToInt32(row["Id"]);
                student.name = Convert.ToString(row["Name"]);
                student.course = Convert.ToString(row["Course"]);

                studentdatas.Add(student);
            }
            sqlconn.Close();
            return studentdatas;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {

            return "value1";
    }

    // POST api/<ValuesController>
    [HttpPost]
        public void Post([FromBody] value value)
        {
          
            SqlConnection sqlconn = new SqlConnection(@"Data Source=DESKTOP-FQMAG4V;Initial catalog=employesdetail;User=sa;Password=ayush@123;");
            sqlconn.Open();
            SqlCommand sqlcommand = new SqlCommand("INSERT INTO studentdetails (name,course) VALUES (@name,@course)",sqlconn);
            sqlcommand.Parameters.Add("@name", System.Data.SqlDbType.VarChar);
            sqlcommand.Parameters.Add("@course", System.Data.SqlDbType.VarChar);
            sqlcommand.Parameters["@name"].Value = value.name;
            sqlcommand.Parameters["@course"].Value = value.course;
            sqlcommand.ExecuteNonQuery();
            sqlconn.Close();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] value value)
        {
            SqlConnection sqlconn = new SqlConnection(@"Data Source=DESKTOP-FQMAG4V;Initial catalog=employesdetail;User=sa;Password=ayush@123;");
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand("UPDATE studentdetails SET course=@course,name=@name WHERE id=@id", sqlconn);
            sqlcmd.Parameters.Add("@course", System.Data.SqlDbType.VarChar);
            sqlcmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar);
            sqlcmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            sqlcmd.Parameters["@course"].Value = value.course;
            sqlcmd.Parameters["@name"].Value = value.name;
            sqlcmd.Parameters["@id"].Value =id;
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]

        public void Delete(int id)
        {
            SqlConnection sqlconn = new SqlConnection(@"Data Source=DESKTOP-FQMAG4V;Initial catalog=employesdetail;user=sa;Password=ayush@123;");
            sqlconn.Open();
            SqlCommand sql = new SqlCommand("DELETE FROM studentdetails WHERE id=@id",sqlconn);
            sql.Parameters.Add("@id", System.Data.SqlDbType.Int);
            sql.Parameters["@id"].Value = id;
            sql.ExecuteNonQuery();
            sqlconn.Close();
        }
    }

    internal class TESTEntities
    {
    }
}
