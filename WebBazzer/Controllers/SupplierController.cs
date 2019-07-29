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

namespace WebBazzer.Controllers
{
    public class SupplierController : Controller
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["WebBazer"].ConnectionString;
        SupplierManager SupplierManager;
        public SupplierController()
        {
            SupplierManager = new SupplierManager();
        }
        public ActionResult Index()
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Supplier", sqlCon);
                sqlDa.Fill(dtblProduct);
            }
            return View(dtblProduct);
        }
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Suppliers supplier)
        {
            var fileName = Path.GetFileNameWithoutExtension(supplier.FileName.FileName);
            
            var extention = Path.GetExtension(supplier.FileName.FileName);


            string path = Path.Combine(Server.MapPath("~/ProductImageFile/"), fileName + extention);
            supplier.ImageUrl = path;
            supplier.FileName.SaveAs(path);
                string message = SupplierManager.Save(supplier);
                ViewBag.Message = message;
                ModelState.Clear();
            
            return View();
        }

        public ActionResult Edit(int id)
        {
            Suppliers supplier = new Suppliers();
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM Supplier Where Id = @id";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@id", id);
                sqlDa.Fill(dtblProduct);
            }
            if (dtblProduct.Rows.Count == 1)
            {
                supplier.Id = Convert.ToInt32(dtblProduct.Rows[0][0].ToString());
                supplier.FirstName = dtblProduct.Rows[0][1].ToString();
                supplier.LastName = dtblProduct.Rows[0][2].ToString();
                supplier.Email = dtblProduct.Rows[0][3].ToString();
                supplier.Age = Convert.ToInt32(dtblProduct.Rows[0][4].ToString());
                supplier.Address = dtblProduct.Rows[0][5].ToString();
                supplier.Gender = dtblProduct.Rows[0][6].ToString();
                supplier.MobileNo = dtblProduct.Rows[0][7].ToString();
                supplier.ImageUrl = dtblProduct.Rows[0][8].ToString();
                return View(supplier);
            }
            else
                return RedirectToAction("Index");
        }
         [HttpPost]
        public ActionResult Edit(Suppliers supplier)
        {
            //ViewBag.Category = CategoryManager.GetSelectListItemsForDropdown();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE  Supplier SET FirstName=@firstName,LastName=@lastName,Email=@email,Age=@age,Address=@address,Gender=@gender,MobileNo=@mobileNo,ImageUrl=@imageUrl WHERE Id=@id";
                SqlCommand Command = new SqlCommand(query, sqlCon);
                Command.Parameters.AddWithValue("@id", supplier.Id);
                Command.Parameters.AddWithValue("@firstName", supplier.FirstName);
                Command.Parameters.AddWithValue("@lastName", supplier.LastName);
                Command.Parameters.AddWithValue("@email", supplier.Email);
                Command.Parameters.AddWithValue("@age", supplier.Age);
                Command.Parameters.AddWithValue("@address", supplier.Address);
                Command.Parameters.AddWithValue("@gender", supplier.Gender);
                Command.Parameters.AddWithValue("@mobileNo", supplier.MobileNo);
                Command.Parameters.AddWithValue("@imageUrl", supplier.ImageUrl);
                Command.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Supplier WHere Id = @id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
      
	}
}