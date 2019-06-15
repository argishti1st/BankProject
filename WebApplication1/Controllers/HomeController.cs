using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using UserCreation.Models;
using WebApplication1.Action_classes;

namespace UserCreation.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }

        UserCreation.Models.userlog userlog = new UserCreation.Models.userlog();
        //LogIn command
        [HttpPost]
        //[Authorize]
        public ActionResult Index(FormCollection fc)
        {
            int res = userlog.Login(fc["userName"], fc["password"]);
            if (res == 1)
            {
                return RedirectToAction("Customers");
            }
            else
            {
                TempData["msg"] = "UserName or password is wrong!";
            }
            return View();


        }


        List<Customer> customer = new List<Customer>();
        //Customer creation command
        //[HttpGet]
        public ActionResult Customers(string fName, string lName)
        {

            string connectionString =
            ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                string query = "spSearch";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@firstName", clientSearch + "%");

                SqlParameter paramFirstName = new SqlParameter("@firstName", fName);
                cmd.Parameters.Add(paramFirstName);


                SqlParameter paramLastName = new SqlParameter("@lastName", lName);
                cmd.Parameters.Add(paramLastName);


                //SqlParameter paramMiddleName = new SqlParameter
                //{
                //    ParameterName = "@lastName",
                //    Value = customer.middq
                //};
                //cmd.Parameters.Add(paramMiddleName);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    customer.Add(new Customer
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        FirstName = Convert.ToString(dr["firstName"]),
                        LastName = Convert.ToString(dr["lastName"]),
                        MiddleName = Convert.ToString(dr["middleName"]),
                        DateOfBirth = Convert.ToDateTime(dr["dateofbirth"]),
                        Gender = Convert.ToString(dr["gender"]),
                        Passport = Convert.ToString(dr["passport"]),
                        Email = Convert.ToString(dr["email"]),
                        //ZipCode = Convert.ToString(dr["ZipCode"]),
                        //Address = Convert.ToString(dr["Address"]),
                        //Passport = Convert.ToString(dr["Passport"]),
                        //Mobile = Convert.ToString(dr["Mobile"]),
                        CreatedAt = Convert.ToDateTime(dr["createdAt"])
                    });
                }
                ModelState.Clear();
                return View(customer);
            }

        }

        //Delete command
        public ActionResult Delete(int Id)
        {

            string connectionString =
           ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("spDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = Id
                };
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Customers", "Home");
        }

        //Edit Post command
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            Console.Write(errors);
            if (ModelState.IsValid)
            {
                string connectionString =
           ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand("spEditCustomer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramId = new SqlParameter
                    {
                        ParameterName = "@id",
                        Value = customer.Id
                    };
                    cmd.Parameters.Add(paramId);

                    SqlParameter paramFirstName = new SqlParameter
                    {
                        ParameterName = "@firstName",
                        Value = customer.FirstName
                    };
                    cmd.Parameters.Add(paramFirstName);

                    SqlParameter paramLastName = new SqlParameter
                    {
                        ParameterName = "@lastName",
                        Value = customer.LastName
                    };
                    cmd.Parameters.Add(paramLastName);

                    SqlParameter paramMiddleName = new SqlParameter
                    {
                        ParameterName = "@middleName",
                        Value = customer.MiddleName
                    };
                    cmd.Parameters.Add(paramMiddleName);

                    SqlParameter paramDateOfBirth = new SqlParameter
                    {
                        ParameterName = "@dateOfBirth",
                        Value = customer.DateOfBirth
                    };
                    cmd.Parameters.Add(paramDateOfBirth);

                    SqlParameter paramGender = new SqlParameter
                    {
                        ParameterName = "@gender",
                        Value = customer.Gender
                    };
                    cmd.Parameters.Add(paramGender);

                    SqlParameter paramEmail = new SqlParameter
                    {
                        ParameterName = "@email",
                        Value = customer.Email
                    };
                    cmd.Parameters.Add(paramEmail);

                    SqlParameter paramPassport = new SqlParameter
                    {
                        ParameterName = "@passport",
                        Value = customer.Passport
                    };
                    cmd.Parameters.Add(paramPassport);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spEditAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramId = new SqlParameter
                    {
                        ParameterName = "@id",
                        Value = customer.Addresses[0].Id
                    };
                    cmd.Parameters.Add(paramId);

                    SqlParameter paramCountry = new SqlParameter
                    {
                        ParameterName = "@country",
                        Value = customer.Addresses[0].Country
                    };
                    cmd.Parameters.Add(paramCountry);

                    SqlParameter paramCity = new SqlParameter
                    {
                        ParameterName = "@city",
                        Value = customer.Addresses[0].City
                    };
                    cmd.Parameters.Add(paramCity);

                    SqlParameter paramStreet = new SqlParameter
                    {
                        ParameterName = "@street",
                        Value = customer.Addresses[0].Street
                    };
                    cmd.Parameters.Add(paramStreet);

                    SqlParameter paramApartment = new SqlParameter
                    {
                        ParameterName = "@apartment",
                        Value = customer.Addresses[0].Apartment
                    };
                    cmd.Parameters.Add(paramApartment);

                    SqlParameter paramId1 = new SqlParameter
                    {
                        ParameterName = "@id1",
                        Value = customer.Addresses[1].Id
                    };
                    cmd.Parameters.Add(paramId1);

                    SqlParameter paramCountry1 = new SqlParameter
                    {
                        ParameterName = "@country1",
                        Value = customer.Addresses[1].Country
                    };
                    cmd.Parameters.Add(paramCountry1);

                    SqlParameter paramCity1 = new SqlParameter
                    {
                        ParameterName = "@city1",
                        Value = customer.Addresses[1].City
                    };
                    cmd.Parameters.Add(paramCity1);

                    SqlParameter paramStreet1 = new SqlParameter
                    {
                        ParameterName = "@street1",
                        Value = customer.Addresses[1].Street
                    };
                    cmd.Parameters.Add(paramStreet1);

                    SqlParameter paramApartment1 = new SqlParameter
                    {
                        ParameterName = "@apartment1",
                        Value = customer.Addresses[1].Apartment
                    };
                    cmd.Parameters.Add(paramApartment1);

                    con.Open();
                    cmd.ExecuteNonQuery();

                }

                for (int i = 0; i < customer.Phones.Count; i++)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spEditPhones", con);
                        cmd.CommandType = CommandType.StoredProcedure;



                        SqlParameter paramId = new SqlParameter
                        {
                            ParameterName = "@id",
                            Value = customer.Phones[i].Id
                        };
                        cmd.Parameters.Add(paramId);

                        SqlParameter paramPhone = new SqlParameter
                        {
                            ParameterName = "@phone",
                            Value = customer.Phones[i].Phone
                        };
                        cmd.Parameters.Add(paramPhone);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return RedirectToAction("Customers", "Home");
            }


            else { return View(customer); }
        }

        //Edit get command
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Edit edit = new Edit();
            edit.EditGet(id);
           // string connectionString =
           //ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
           // Customer customer = new Customer(new List<Address>(), new List<Phones>());
           // DataTable dataTableCustomers = new DataTable();
           // using (SqlConnection con = new SqlConnection(connectionString))
           // {
           //     con.Open();
           //     SqlCommand cmd = new SqlCommand("spEditGet", con);
           //     cmd.CommandType = CommandType.StoredProcedure;
           //     SqlParameter paramId = new SqlParameter
           //     {
           //         ParameterName = "@customerId",
           //         Value = id
           //     };
           //     cmd.Parameters.Add(paramId);
           //     SqlDataAdapter da = new SqlDataAdapter("spEditGet", con);
           //     da.SelectCommand.CommandType = CommandType.StoredProcedure;
           //     da.SelectCommand.Parameters.Add("@customerId", id);
           //     da.Fill(dataTableCustomers);
           // }

           // customer.Id = Convert.ToInt32(dataTableCustomers.Rows[0][0].ToString());
           // customer.FirstName = dataTableCustomers.Rows[0][1].ToString();
           // customer.LastName = dataTableCustomers.Rows[0][2].ToString();
           // customer.MiddleName = dataTableCustomers.Rows[0][3].ToString();
           // customer.DateOfBirth = Convert.ToDateTime(dataTableCustomers.Rows[0][4].ToString());
           // customer.Gender = dataTableCustomers.Rows[0][5].ToString();
           // customer.Passport = dataTableCustomers.Rows[0][6].ToString();
           // customer.Email = dataTableCustomers.Rows[0][7].ToString();


           // for (int i = 0; i < dataTableCustomers.Rows.Count; i++)
           // {

           //     List<Address> adress = new List<Address>
           //     {
           //         new Address {Id = Convert.ToInt32(dataTableCustomers.Rows[i][13].ToString()), CustomerId = Convert.ToInt32(dataTableCustomers.Rows[0][0].ToString()),
           //         Country = dataTableCustomers.Rows[i][8].ToString(), City = dataTableCustomers.Rows[i][9].ToString(),
           //         Apartment = dataTableCustomers.Rows[i][11].ToString(), Street = dataTableCustomers.Rows[i][10].ToString(),
           //         AddressType = dataTableCustomers.Rows[i][12].ToString()}
           //     };

           //     customer.Addresses.AddRange(adress);

           // }




           // DataTable dataTablePhones = new DataTable();
           // using (SqlConnection con = new SqlConnection(connectionString))
           // {
           //     con.Open();
           //     SqlCommand cmd = new SqlCommand("spGetPhone", con);
           //     cmd.CommandType = CommandType.StoredProcedure;
           //     SqlParameter paramId = new SqlParameter
           //     {
           //         ParameterName = "@id",
           //         Value = id
           //     };
           //     cmd.Parameters.Add(paramId);
           //     SqlDataAdapter da = new SqlDataAdapter("spGetPhone", con);
           //     //SqlDataReader dr = cmd.ExecuteReader();
           //     //dataTablePhones.Load(dr);
           //     da.SelectCommand.CommandType = CommandType.StoredProcedure;
           //     da.SelectCommand.Parameters.Add("@id", id);
           //     da.Fill(dataTablePhones);
           // }
           // for (int i = 0; i < dataTablePhones.Rows.Count; i++)
           // {
           //     List<Phones> phones = new List<Phones>
           //     {
           //         new Phones{Id = Convert.ToInt32(dataTablePhones.Rows[i][0].ToString()), CustomerId = Convert.ToInt32(dataTablePhones.Rows[i][1].ToString()), Phone = dataTablePhones.Rows[i][2].ToString()}
           //     };

           //     customer.Phones.AddRange(phones);

           // }
            return View(customer);


        }

    }
}