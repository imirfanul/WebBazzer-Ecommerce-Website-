using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBazzer.Models
{
    [MetadataType(typeof(SubCategorys))]

    public partial class SubCategory
    {
    }

    public class SubCategorys
    {
        public int Id { get; set; }
         [Required(ErrorMessage = "Please Select A Categry Name")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please Enter Categry Name")]
        public string SName { get; set; }
        public string Category { get; set; }
    }
}