using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UserCreation.Models;

namespace WebApplication1.Action_classes
{
    public class Edit
    {
        public Customer EditGet(int id)
        {
            string connectionString =
          ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            Customer customer = new Customer(new List<Address>(), new List<Phones>());
            DataTable dataTableCustomers = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spEditGet", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter
                {
                    ParameterName = "@customerId",
                    Value = id
                };
                cmd.Parameters.Add(paramId);
                SqlDataAdapter da = new SqlDataAdapter("spEditGet", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@customerId", id);
                da.Fill(dataTableCustomers);
            }

            customer.Id = Convert.ToInt32(dataTableCustomers.Rows[0][0].ToString());
            customer.FirstName = dataTableCustomers.Rows[0][1].ToString();
            customer.LastName = dataTableCustomers.Rows[0][2].ToString();
            customer.MiddleName = dataTableCustomers.Rows[0][3].ToString();
            customer.DateOfBirth = Convert.ToDateTime(dataTableCustomers.Rows[0][4].ToString());
            customer.Gender = dataTableCustomers.Rows[0][5].ToString();
            customer.Passport = dataTableCustomers.Rows[0][6].ToString();
            customer.Email = dataTableCustomers.Rows[0][7].ToString();


            for (int i = 0; i < dataTableCustomers.Rows.Count; i++)
            {

                List<Address> adress = new List<Address>
                {
                    new Address {Id = Convert.ToInt32(dataTableCustomers.Rows[i][13].ToString()), CustomerId = Convert.ToInt32(dataTableCustomers.Rows[0][0].ToString()),
                    Country = dataTableCustomers.Rows[i][8].ToString(), City = dataTableCustomers.Rows[i][9].ToString(),
                    Apartment = dataTableCustomers.Rows[i][11].ToString(), Street = dataTableCustomers.Rows[i][10].ToString(),
                    AddressType = dataTableCustomers.Rows[i][12].ToString()}
                };

                customer.Addresses.AddRange(adress);

            }




            DataTable dataTablePhones = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetPhone", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                cmd.Parameters.Add(paramId);
                SqlDataAdapter da = new SqlDataAdapter("spGetPhone", con);
                //SqlDataReader dr = cmd.ExecuteReader();
                //dataTablePhones.Load(dr);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@id", id);
                da.Fill(dataTablePhones);
            }
            for (int i = 0; i < dataTablePhones.Rows.Count; i++)
            {
                List<Phones> phones = new List<Phones>
                {
                    new Phones{Id = Convert.ToInt32(dataTablePhones.Rows[i][0].ToString()), CustomerId = Convert.ToInt32(dataTablePhones.Rows[i][1].ToString()), Phone = dataTablePhones.Rows[i][2].ToString()}
                };

                customer.Phones.AddRange(phones);

            }

            return customer;
        }
    }
}