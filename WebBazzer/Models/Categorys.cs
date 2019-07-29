using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace WebBazzer.Models
{
    [MetadataType(typeof(Categorys))]

    public partial class Category
    {
    }
   
        public class Categorys
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Please Enter Categry Name")]
            public string  CName { get; set; }
        }
    
}