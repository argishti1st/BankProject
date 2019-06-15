using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserCreation.Models
{
    public class Phones
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Պարտադիր լրացման դաշտ")]
        [RegularExpression(@"^\+?\d{11,12}$", ErrorMessage = "Մուտքագրեք վավեր հեռախոսահամար։ Օր. '+' և 11-12 նիշ")]
        public string Phone { get; set; }
    }
}