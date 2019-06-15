using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserCreation.Models
{
    public class Address
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        //[Required(ErrorMessage = "Պարտադիր լրացման դաշտ")]
        //[RegularExpression(@"^\p{L}{1,50}$", ErrorMessage = "Պետության անվանումը չի կարող պարունակել թիվ")]
        public string Country { get; set; }


        //[Required(ErrorMessage = "Պարտադիր լրացման դաշտ")]
        //[RegularExpression(@"^\p{L}{1,50}$", ErrorMessage = "Քաղաքի անվանումը չի կարող պարունակել թիվ")]
        public string City { get; set; }

        public string Street { get; set; }


        public string Apartment { get; set; }

        public string AddressType { get; set; }

    }
}