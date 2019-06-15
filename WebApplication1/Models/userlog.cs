using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserCreation.Models
{
    [Table("users")]
    public class userlog
    {
        public int Login(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
            {
                int res = 0;
                con.Open();
                SqlCommand com = new SqlCommand("spLogin", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@username", username);
                com.Parameters.AddWithValue("@password", password);
                SqlParameter oblogin = new SqlParameter();
                oblogin.ParameterName = "@IsValid";
                oblogin.SqlDbType = SqlDbType.Bit;
                oblogin.Direction = ParameterDirection.Output;
                com.Parameters.Add(oblogin);


                com.ExecuteNonQuery();


                res = Convert.ToInt32(oblogin.Value);
                return res;

            }

        }
    }
}