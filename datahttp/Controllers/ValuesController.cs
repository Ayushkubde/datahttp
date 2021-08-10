using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Web.Http.Cors;
using System.Data.SqlClient;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication5.Controllers
{
    [Route("api/valuescontroller")]
    [ApiController]
    
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<value> Get()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source= DESKTOP-FQMAG4V; Initial Catalog=employesdetail; User=sa; Password=ayush@123");
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM employetable", sqlConnection);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            List<value> employedatas = new List<value>();
            
            foreach(DataRow  row in dtbl.Rows)
            {
                value employe = new value();
                employe.employe_id = Convert.ToInt32(row["employe_id"]);
                employe.employename = Convert.ToString(row["employename"]);
                employe.designation = Convert.ToString(row["designation"]);
                employe.salary = Convert.ToInt32(row["salary"]);
                employe.email = Convert.ToString(row["email"]);
                employe.mobile = Convert.ToInt32(row["mobile"]);
                employe.qualification = Convert.ToString(row["qualification"]);
                employe.manager = Convert.ToString(row["manager"]);

                employedatas.Add(employe);
            }
            sqlConnection.Close();
            return employedatas;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] value value)
        {
            SqlConnection sqlConnection = new SqlConnection(@"DataSource=DESKTOP-FQMAG4V; Initial catalog=employesdetail;user=sa;password=ayush@123");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("Insert INTO employetable(employe_id, employename, designation, salary, email, mobile, qualifcations, manager) VALUES(@employe_id,@employename,@designation,@salary,@email,@mobile,@qualification,@manager)", sqlConnection);
            sqlCommand.Parameters.Add("@employe_id", System.Data.SqlDbType.Int);
            sqlCommand.Parameters.Add("@employename", System.Data.SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@designation", System.Data.SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@salary", System.Data.SqlDbType.Int);
            sqlCommand.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@mobile", System.Data.SqlDbType.Int);
            sqlCommand.Parameters.Add("@qualification", System.Data.SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@manager", System.Data.SqlDbType.VarChar);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] value value)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-FQMAG4V; Initial catalog=employesdetail; user=sa; password=ayush@123;");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("UPDATE employetable SET  employename=@employename,designation=@designation,salary=@salary,email=@email,mobile=@mobile,qualification=@qualification,manager=@manager WHERE employe_id=@employe_id",sqlConnection);
            sqlCommand.Parameters.Add("@employe_id", System.Data.SqlDbType.Int);
            sqlCommand.Parameters.Add("@employename", System.Data.SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@designation", System.Data.SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@salary", System.Data.SqlDbType.Int);
            sqlCommand.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@mobile", System.Data.SqlDbType.Int);
            sqlCommand.Parameters.Add("@qualification", System.Data.SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@manager", System.Data.SqlDbType.VarChar);
            sqlCommand.Parameters["@employename"].Value = value.employename;
            sqlCommand.Parameters["@designation"].Value = value.designation;
            sqlCommand.Parameters["@salary"].Value = value.salary;
            sqlCommand.Parameters["@email"].Value = value.email;
            sqlCommand.Parameters["@mobile"].Value = value.mobile;
            sqlCommand.Parameters["@qualification"].Value = value.qualification;
            sqlCommand.Parameters["@manager"].Value = value.manager;
            sqlCommand.Parameters["@employe_id"].Value = id;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        { 
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-FQMAG4V; Initial catalog=employesdetail;user=sa;password=ayush@123;");
            sqlConnection.Open();
            SqlCommand sql = new SqlCommand("DELETE FROM employetable WHERE employe_id=@employe_id",sqlConnection);
            sql.Parameters.Add("@employe_id", System.Data.SqlDbType.Int);
            sql.Parameters["@employe_id"].Value = id;
            sql.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
