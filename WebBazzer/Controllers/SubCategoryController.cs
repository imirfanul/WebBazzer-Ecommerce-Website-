using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBazzer.Models;
using WebBazzer.BLL;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data.Entity;

namespace WebBazzer.Controllers
{
    public class SubCategoryController : Controller
    {
        WebBazerEntities db = new WebBazerEntities();
        string connectionString = WebConfigurationManager.ConnectionStrings["WebBazer"].ConnectionString;
        private SubCategoryManager SubCategoryManager;
        private CategoryManager CategoryManager;
        public SubCategoryController()
        {
            SubCategoryManager = new SubCategoryManager();
            CategoryManager = new CategoryManager();
        }

        public ActionResult Index()
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM AllCategorisView", sqlCon);
                sqlDa.Fill(dtblProduct);
            }
            return View(dtblProduct);
        }

        public ActionResult Save()
        {
            ViewBag.Category = CategoryManager.GetSelectListItemsForDropdown();
            return View();

        }
        [HttpPost]
        public ActionResult Save(SubCategorys subCategory)
        {
          
                ViewBag.Category = CategoryManager.GetSelectListItemsForDropdown();
                string message = SubCategoryManager.Save(subCategory);
                ViewBag.Message = message;
                ModelState.Clear();
                return View();
          

        }

        
         //GET: /Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Category = CategoryManager.GetSelectListItemsForDropdown();
            SubCategory category = new SubCategory();
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM SubCategory Where Id = @id";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@id", id);
                sqlDa.Fill(dtblProduct);
            }
            //if (dtblProduct.Rows.Count == 1)
            //{
            category.Id = Convert.ToInt32(dtblProduct.Rows[0][0].ToString());
            category.SName = dtblProduct.Rows[0][3].ToString();
            category.CategoryId = Convert.ToInt32(dtblProduct.Rows[0][1]);

            return View(category);
            //}
            //    else
            //        return RedirectToAction("Index");
            //}
        }
        //
        // POST: /Product/Edit/5
        [HttpPost]
        public ActionResult Edit(SubCategory subCategory)
        {
            ViewBag.Category = CategoryManager.GetSelectListItemsForDropdown();
            //ViewBag.Category = CategoryManager.GetSelectListItemsForDropdown();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE SubCategory SET SName = @name,CategoryId=@categoryId WHere Id = @id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", subCategory.Id);
                sqlCmd.Parameters.AddWithValue("@name", subCategory.SName);
                sqlCmd.Parameters.AddWithValue("@categoryId", subCategory.CategoryId);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM SubCategory WHere Id = @id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

       
      
	}
}