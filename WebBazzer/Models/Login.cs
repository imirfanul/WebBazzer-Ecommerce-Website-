using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBazzer.Models
{
    public  class Login
    {
        public int Id { get; set; }
         [Required(ErrorMessage = "Pleasee Enter Your Email")]
         [EmailAddress(ErrorMessage = "Please Enter A Valied Email ")]
         [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
         [Required(ErrorMessage = "Pleasee Enter Your Password")]
         [StringLength(14, MinimumLength = 5, ErrorMessage = "Password must be 6 word long minimum")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
         public string LoginErrorMessage { get; set; } 
    }
}