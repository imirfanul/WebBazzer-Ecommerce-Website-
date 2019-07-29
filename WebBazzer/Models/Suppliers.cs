using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBazzer.Models
{
    [MetadataType(typeof(Supplier))]
    public partial class Supplier
    {
    }
    public class Suppliers
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter First Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name contains only Alphabets")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name contains only Alphabets")]
        public string LastName { get; set; }
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
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Please Select A Image")]
        [DataType(DataType.Upload, ErrorMessage = "Please Select A Image")]
        public HttpPostedFileBase FileName { get; set; }

    }
}