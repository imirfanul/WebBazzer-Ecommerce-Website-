using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBazzer.Models;
using WebBazzer.BLL;
using System.Configuration;
using System.IO;
using System.Data;
using System.Drawing;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data.Entity;


namespace WebBazzer.Controllers
{
    public class ProductController : Controller
    {
        WebBazerEntities db = new WebBazerEntities();
        string connectionString = WebConfigurationManager.ConnectionStrings["WebBazer"].ConnectionString;
         private SubCategoryManager SubCategoryManager;
        private CategoryManager CategoryManager;
        private ProductManager ProductManager;
        public ProductController()
        {
            SubCategoryManager = new SubCategoryManager();
            CategoryManager = new CategoryManager();
            ProductManager = new ProductManager();
        }
        public ActionResult Index()
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM ProductDetails", sqlCon);
                sqlDa.Fill(dtblProduct);
            }
            return View(dtblProduct);
        }

        //public ActionResult Index()
        //{
        //    List<Products> products = ProductManager.GetAllProducts();
        //    return View(products);
        //}
        public ActionResult Save()
        {
            ViewBag.Category = CategoryManager.GetSelectListItemsForDropdown();
            ViewBag.SubCategory = SubCategoryManager.GetSelectListItemsForDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Products products)
        {
            ViewBag.Category = CategoryManager.GetSelectListItemsForDropdown();
            ViewBag.SubCategory = SubCategoryManager.GetSelectListItemsForDropdown();
            //if (ModelState.IsValid)
            string ppp = "/ProductImageFile/";
           
            //{

                 
                  var fileName = Path.GetFileNameWithoutExtension(products.FileName.FileName);
                 // string date = DateTime.Now.Date.ToString();
                  var extention = Path.GetExtension(products.FileName.FileName);
                  var file = ppp + fileName + extention;
                  //if (extention.ToLower() == ".Jepg" || extention.ToLower() == ".Jpg" || extention.ToLower() == ".Png")
                  //{

                  string path = Path.Combine(Server.MapPath(ppp), fileName + extention);
                      products.ImageUrl = path;
                      products.FileName.SaveAs(path);
                      
                      string message = ProductManager.Save(products);
                      ViewBag.Message = message;
                  //}





                      ModelState.Clear();
                return View();
           
            
        }
        //
        // GET: /Product/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    ViewBag.Category = CategoryManager.GetSelectListItemsForDropdown();
        //    ViewBag.SubCategory = SubCategoryManager.GetSelectListItemsForDropdown();
        //    Products products = new Products();
        //    DataTable dtblProduct = new DataTable();
        //    using (SqlConnection sqlCon = new SqlConnection(connectionString))
        //    {
        //        sqlCon.Open();
        //        string query = "SELECT * FROM Products Where Id = @id";
        //        SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
        //        sqlDa.SelectCommand.Parameters.AddWithValue("@id", id);
        //        sqlDa.Fill(dtblProduct);
        //    }
        //    if (dtblProduct.Rows.Count == 1)
        //    {
        //        products.Id = Convert.ToInt32(dtblProduct.Rows[0][0].ToString());                
        //        products.CategoryId = Convert.ToInt32(dtblProduct.Rows[0][1].ToString());
        //        products.SubCategoryId = Convert.ToInt32(dtblProduct.Rows[0][2].ToString());
        //        products.PName = dtblProduct.Rows[0][3].ToString();
        //        products.Price = Convert.ToDecimal(dtblProduct.Rows[0][4].ToString());
        //        products.ReorderLevel = Convert.ToInt32(dtblProduct.Rows[0][5].ToString());
        //        products.Description = dtblProduct.Rows[0][6].ToString();
        //        products.ImageUrl = dtblProduct.Rows[0][7].ToString();

                
        //        products.Discount = Convert.ToDecimal(dtblProduct.Rows[0][9].ToString());
        //        products.AvailableQuantity = Convert.ToInt32(dtblProduct.Rows[0][10]);

        //        return View(products);
        //    }
        //    else
        //        return RedirectToAction("Index");
        //}

        ////
        //// POST: /Product/Edit/5
        //[HttpPost]
        //public ActionResult Edit(Products products)
        //{
        //    ViewBag.Category = CategoryManager.GetSelectListItemsForDropdown();
        //    ViewBag.SubCategory = SubCategoryManager.GetSelectListItemsForDropdown();
        //    using (SqlConnection sqlCon = new SqlConnection(connectionString))
        //    {
        //        sqlCon.Open();
        //        string query = "UPDATE Products SET CategoryId=@categoryId,SubCategoryId=@subCategoryId, PName = @name ,Price= @price , ReorderLevel = @reorderLevel,Description=@description,ImageUrl=@imageUrl,discount=@discount,ProductAvailable=@productAvailable,AvailableQuantity=@availableQuantity WHere Id = @id";
        //        SqlCommand Command = new SqlCommand(query, sqlCon);
        //        Command.Parameters.AddWithValue("@id", products.Id);
        //        Command.Parameters.AddWithValue("@categoryId", products.CategoryId);
        //        Command.Parameters.AddWithValue("@subCategoryId", products.SubCategoryId);
        //        Command.Parameters.AddWithValue("@name", products.PName);
        //        Command.Parameters.AddWithValue("@price", products.Price);
        //        Command.Parameters.AddWithValue("@reorderLevel", products.ReorderLevel);
        //        Command.Parameters.AddWithValue("@description", products.Description);
        //        Command.Parameters.AddWithValue("@imageUrl", products.ImageUrl);                
        //        Command.Parameters.AddWithValue("@discount", products.Discount);
        //        Command.Parameters.AddWithValue("@productAvailable", products.ProductAvailable);
        //        Command.Parameters.AddWithValue("@availableQuantity", products.AvailableQuantity);
        //        Command.ExecuteNonQuery();
        //    }
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = db.Products.Single(x => x.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category = CategoryManager.GetSelectListItemsForDropdown();
            ViewBag.SubCategory = SubCategoryManager.GetSelectListItemsForDropdown();
            return View("Edit", product);
        }

        //Post Edit
        [HttpPost]
        public ActionResult Edit(Product prod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            ViewBag.Category = CategoryManager.GetSelectListItemsForDropdown();
            ViewBag.SubCategory = SubCategoryManager.GetSelectListItemsForDropdown();
            return View(prod);
        }

        //
        // GET: /Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Products WHere Id = @id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }































       
        //public JsonResult GetSubCategory(int categoryId)
        //{
          
        //    List<AllCategorisView> allCategorisViews = ProductManager.GetSubCategoryByCateoryId(categoryId);

        //    return Json(allCategorisViews, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult GetSubCategoryId(int subCategoryId)
        //{
        //    List<SubCategory> subCategory = SubCategoryManager.GetSubCategoryById(subCategoryId);
        //    return Json(subCategory);
        //}
       
       
       
	}
}