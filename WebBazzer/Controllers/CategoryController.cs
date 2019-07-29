using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBazzer.Models;
using WebBazzer.BLL;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using WebBazzer.Gateway;
using System.Data.Entity;

namespace WebBazzer.Controllers
{
    public class CategoryController : Controller
    {
        WebBazerEntities db = new WebBazerEntities();
        private CategoryManager CategoryManager;
        private LoginController login;
        string connectionString = WebConfigurationManager.ConnectionStrings["WebBazer"].ConnectionString;
        public CategoryController()
        {
            //if(Session["login"]==null)
            //{
            //    //redirect to logincontroller
            //}
            CategoryManager = new CategoryManager();
        }
        [HttpGet]
        public ActionResult Index()
        {

            //return View(db.Categories.ToList());
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Category", sqlCon);
                sqlDa.Fill(dtblProduct);
            }
            return View(dtblProduct);
        }

        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Categorys category)
        {
            if (ModelState.IsValid)
            {
                string message = CategoryManager.Save(category);
                ViewBag.Message = message;
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                string message = "Model State is Invalid";
                return RedirectToAction("Index");
            }

        }

        
         //GET: /Product/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = new Category();
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM Category Where Id = @id";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@id", id);
                sqlDa.Fill(dtblProduct);
            }
            if (dtblProduct.Rows.Count == 1)
            {
                category.Id = Convert.ToInt32(dtblProduct.Rows[0][0].ToString());
                category.CName = dtblProduct.Rows[0][1].ToString();

                return View(category);
            }
            else
                return RedirectToAction("Index");
        }

        //
        // POST: /Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE Category SET CName=@name WHere Id = @id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", category.Id);
                sqlCmd.Parameters.AddWithValue("@name", category.CName);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

      //  [HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    Category category = db.Categories.Single(x => x.Id == id);
        //    if (category == null)
        //    {
        //        return HttpNotFound();
        //    }
           
        //    return View("Edit", category);
        //}

        ////Post Edit
        //[HttpPost]
        //public ActionResult Edit(Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(category).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index", "Product");
        //    }

        //    return View(category);
        //}


        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Category WHere Id = @id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
        //public ActionResult Delete(int id)
        //{
        //    Category category = db.Categories.Find(id);
        //    if (category == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(category);

        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Category category = db.Categories.Find(id);
        //    db.Categories.Remove(category);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    base.Dispose(disposing);
        //}

        //public ActionResult Details(int id)
        //{
        //    Category category = db.Categories.Find(id);
        //    if (category == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(category);
        //}

    }
}
