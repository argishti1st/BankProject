using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using UserCreation.Models;
using System.Web.Mvc;

namespace UserCreation.Models
{
    public class Customer
    {
        public Customer(List<Address> addresses, List<Phones> phones)
        {
            Phones = new List<Phones>();
            Addresses = new List<Address>();
        }

        public Customer()
        {

        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Պարտադիր լրացման դաշտ")]
        [RegularExpression(@"^\p{L}{1,50}$", ErrorMessage = "Անունը չի կարող պարունակել թիվ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Պարտադիր լրացման դաշտ")]
        [RegularExpression(@"^\p{L}{1,50}$", ErrorMessage = "Ազգանունը չի կարող պարունակել թիվ")]
        public string LastName { get; set; }
        [RegularExpression(@"^\p{L}{1,50}$", ErrorMessage = "Հայրանունը չի կարող պարունակել թիվ")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Պարտադիր լրացման դաշտ")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Պարտադիր լրացման դաշտ")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Պարտադիր լրացման դաշտ")]
        public string Passport { get; set; }

        [Required(ErrorMessage = "Պարտադիր լրացման դաշտ")]
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<Address> Addresses { get; set; }

        public List<Phones> Phones { get; set; }



        //public void CreateClient(Customer customer)
        //{

        //}


    }
}