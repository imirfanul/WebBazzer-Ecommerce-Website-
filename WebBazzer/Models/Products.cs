using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBazzer.Models
{
     //[MetadataType(typeof(Products))]
    //public partial class Product
    //{
    //}
     public class Products
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pleasee Select A Category")]

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Pleasee Select A Sub Category")]

        [Display(Name = "SubCategory")]
        public int SubCategoryId { get; set; }
         [Required(ErrorMessage = "Please Enter A Valied Name")]
        //[RegularExpression("[a-zA-Z ]*$", ErrorMessage = "Please Enter A Valied Name")]
       
        [StringLength(20, ErrorMessage = "Name must be 2 to 20 character long", MinimumLength = 2)]
        public string PName { get; set; }
        [Required(ErrorMessage = "Please Input Some Description About This Product")]
        //[RegularExpression("[a-zA-Z ]*$", ]
        [StringLength(200, ErrorMessage = "Name must be 2 to 200 character long", MinimumLength = 2)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Pleasee enter Product Price")]
      
        public decimal Price { get; set; }
         
        public decimal OldPrice { get; set; }
         
        public decimal Discount { get; set; }
         
       // public int UnitOnOrder { get; set; }
       // public string OfferTitle { get; set; }
        
        public int ReorderLevel { get; set; }
         
      //  public string AltText { get; set; }
         [Required(ErrorMessage = "Pleasee Insert Product Image")]
         [Display(Name = "Image")]
        public string ImageUrl { get; set; }
         public int ProductAvailable { get; set; }
         public HttpPostedFileBase FileName { get; set; }

         [Required(ErrorMessage = "Pleasee enter Quantity")]
         [Display(Name = "Stock In Quantity")]
         public int AvailableQuantity { get; set; }
         public string Category { get; set; }
         public string SubCategory { get; set; }
    }
}