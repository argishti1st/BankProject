using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserCreation.Models;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Action_classes;

namespace UserCreation.Controllers
{
    public class CreateController : Controller
    {
        // GET: Create
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Customer());

        }


        [HttpPost]
        public ActionResult Index(Customer customer)
        {
            Create cr = new Create();
            cr.Creation(customer);

            //string connectionString =
            //ConfigurationManager.ConnectionStrings["connection"].ConnectionString;


            var errors = ModelState.Values.SelectMany(v => v.Errors);
            Console.Write(errors);
            if (ModelState.IsValid)
            {
                
            //customer.DateOfBirth = Convert.ToDateTime(customer.DateOfBirth);
            //int customerId;
            //using (SqlConnection con = new SqlConnection(connectionString))
            //{

            //    SqlCommand cmd = new SqlCommand("spAddClient2", con);
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    SqlParameter paramFirstName = new SqlParameter
            //    {
            //        ParameterName = "@firstName",
            //        Value = customer.FirstName
            //    };
            //    cmd.Parameters.Add(paramFirstName);

            //    SqlParameter paramLastName = new SqlParameter
            //    {
            //        ParameterName = "@lastName",
            //        Value = customer.LastName
            //    };
            //    cmd.Parameters.Add(paramLastName);

            //    SqlParameter paramMiddleName = new SqlParameter
            //    {
            //        ParameterName = "@middleName",
            //        Value = customer.MiddleName
            //    };
            //    cmd.Parameters.Add(paramMiddleName);

            //    SqlParameter paramDateOfBirth = new SqlParameter
            //    {
            //        ParameterName = "@dateOfBirth",
            //        Value = customer.DateOfBirth
            //    };
            //    cmd.Parameters.Add(paramDateOfBirth);

            //    SqlParameter paramGender = new SqlParameter
            //    {
            //        ParameterName = "@gender",
            //        Value = customer.Gender
            //    };
            //    cmd.Parameters.Add(paramGender);

            //    SqlParameter paramEmail = new SqlParameter
            //    {
            //        ParameterName = "@email",
            //        Value = customer.Email
            //    };
            //    cmd.Parameters.Add(paramEmail);


            //    SqlParameter paramPassport = new SqlParameter
            //    {
            //        ParameterName = "@passport",
            //        Value = customer.Passport
            //    };
            //    cmd.Parameters.Add(paramPassport);


            //    con.Open();
            //    customerId = Convert.ToInt32(cmd.ExecuteScalar());
            //    con.Close();
            //}
            //if (customerId != 0)
            //{
            //    if (customer.Addresses[0] != null)
            //    {
            //        int addressLength = 0;
            //        if (customer.Addresses[1].Country == null)
            //        {
            //            addressLength = 1;
            //        }
            //        else
            //        {
            //            addressLength = 2;
            //        }

            //        for (int i = 0; i < addressLength; i++)
            //        {
            //            using (SqlConnection con = new SqlConnection(connectionString))
            //            {
            //                SqlCommand addaddress = new SqlCommand("spAddAddress", con);
            //                addaddress.CommandType = CommandType.StoredProcedure;


            //                SqlParameter paramCustomer = new SqlParameter
            //                {
            //                    ParameterName = "@customerId",
            //                    Value = customerId
            //                };
            //                addaddress.Parameters.Add(paramCustomer);

            //                SqlParameter paramCountry = new SqlParameter
            //                {
            //                    ParameterName = "@country",
            //                    Value = customer.Addresses[i].Country
            //                };
            //                addaddress.Parameters.Add(paramCountry);

            //                SqlParameter paramCity = new SqlParameter
            //                {
            //                    ParameterName = "@city",
            //                    Value = customer.Addresses[i].City
            //                };
            //                addaddress.Parameters.Add(paramCity);

            //                SqlParameter paramStreet = new SqlParameter
            //                {
            //                    ParameterName = "@street",
            //                    Value = customer.Addresses[i].Street
            //                };
            //                addaddress.Parameters.Add(paramStreet);

            //                SqlParameter paramApartment = new SqlParameter
            //                {
            //                    ParameterName = "@apartment",
            //                    Value = customer.Addresses[i].Apartment
            //                };
            //                addaddress.Parameters.Add(paramApartment);

            //                SqlParameter paramAddressType = new SqlParameter
            //                {
            //                    ParameterName = "@addressType",
            //                    Value = customer.Addresses[i].AddressType
            //                };
            //                addaddress.Parameters.Add(paramAddressType);

            //                if (customer.Addresses[1].Country == null)
            //                {
            //                    SqlParameter paramSame = new SqlParameter
            //                    {
            //                        ParameterName = "@same",
            //                        Value = 1
            //                    };
            //                    addaddress.Parameters.Add(paramSame);
            //                }
            //                else
            //                {
            //                    SqlParameter paramSame = new SqlParameter
            //                    {
            //                        ParameterName = "@same",
            //                        Value = 0
            //                    };
            //                    addaddress.Parameters.Add(paramSame);
            //                }


            //                con.Open();
            //                addaddress.ExecuteNonQuery();
            //            }
            //        }
            //    }
            //    if (customer.Phones[0] != null)
            //    {
            //        for (int i = 0; i < customer.Phones.Count; i++)
            //        {
            //            using (SqlConnection con = new SqlConnection(connectionString))
            //            {
            //                SqlCommand addphones = new SqlCommand("spAddPhone", con);
            //                addphones.CommandType = CommandType.StoredProcedure;



            //                SqlParameter paramCustomer = new SqlParameter
            //                {
            //                    ParameterName = "@customerId",
            //                    Value = customerId
            //                };
            //                addphones.Parameters.Add(paramCustomer);

            //                SqlParameter paramPhone = new SqlParameter
            //                {
            //                    ParameterName = "@phone",
            //                    Value = customer.Phones[i].Phone
            //                };
            //                addphones.Parameters.Add(paramPhone);
            //                con.Open();
            //                addphones.ExecuteNonQuery();
            //            }
            //        }
            //    }
            //}



            return RedirectToAction("Customers", "Home");


            }
            else
            {
                return View();
            }
        }
    }
}