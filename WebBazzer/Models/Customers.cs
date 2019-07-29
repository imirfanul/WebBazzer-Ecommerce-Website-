using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBazzer.Models
{
    [MetadataType(typeof(Coustomer))]
    public partial class Coustomer
    {
    }
    public class Customers
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter First Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name contains only Alphabets")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name contains only Alphabets")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        [StringLength(14, MinimumLength = 6, ErrorMessage = "Password must be 6 word long minimum")]
        [DataType(DataType.Password, ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Please Enter A Unique UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter A Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Age")]

        public int Age { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Enter A Mobile No")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter correct mobile No")]
        public string MobileNo { get; set; }
       
       
        [Required(ErrorMessage = "Please Select A Country")]
        public string Country { get; set; }
         [Required(ErrorMessage = "Please Select A City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Select A Postal Code")]
         public string PostalCode { get; set; }
    }
}