using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebBazzer.Models;

namespace WebBazzer.Gateway
{
    public class ProductGateway : BaseGateway
    {
       
        public int Save(Products products)
        {
          
            Query = "INSERT INTO Products VALUES(@categoryId,@subCategoryId,@name,@price,@reorderLevel,@description,@imageUrl,@oldPrice,@discount,@productAvailable,@availableQuantity)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@categoryId", products.CategoryId);
            Command.Parameters.AddWithValue("@subCategoryId", products.SubCategoryId);
            Command.Parameters.AddWithValue("@name", products.PName);
            Command.Parameters.AddWithValue("@price", products.Price);
            Command.Parameters.AddWithValue("@reorderLevel", products.ReorderLevel);
            Command.Parameters.AddWithValue("@description", products.Description);
            Command.Parameters.AddWithValue("@imageUrl", products.ImageUrl);
            Command.Parameters.AddWithValue("@oldPrice", products.Price);
            Command.Parameters.AddWithValue("@discount", 0.0);
            Command.Parameters.AddWithValue("@productAvailable", 1);
            Command.Parameters.AddWithValue("@availableQuantity", products.AvailableQuantity);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsNameExsists(string name)
        {

            Query = "SELECT * FROM Products WHERE PName='" + name + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }

        public Products GetProductsById(int productsId)
        {
            Query = "SELECT * FROM Products WHERE Id = " + productsId;
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Products products = null;
            if (Reader.HasRows)
            {
                products = new Products();
                products.Id = Convert.ToInt32(Reader["Id"]);
                products.PName = Reader["PName"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return products;
        }

        public List<Products> GetAllProducts()
        {

            Query = "SELECT * FROM ProductDetails";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Products> productsList = new List<Products>();

            while (Reader.Read())
            {
                Products products = new Products();
                products.Id = Convert.ToInt32(Reader["Id"]);
                products.PName = Reader["ProductName"].ToString();
                products.CategoryId = Convert.ToInt32(Reader["CategoryId"]);
                products.SubCategoryId = Convert.ToInt32(Reader["SubCategoryId"]);
                products.Price = Convert.ToDecimal(Reader["Price"]);
                products.ImageUrl = Reader["ImageUrl"].ToString();
               
                products.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
               
              
                products.ProductAvailable = Convert.ToInt32(Reader["ProductAvailable"]);
              
               
                products.Category = Reader["Category"].ToString();
                products.SubCategory = Reader["SubCategory"].ToString();



                productsList.Add(products);
                
            }
            return productsList;
        }

        public Products GetProductsNameById(string categoryName)
        {
            Query = "SELECT Id,Name FROM Products WHERE CName = " + categoryName;
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Products products = null;
            if (Reader.HasRows)
            {
                products = new Products();
                products.Id = Convert.ToInt32(Reader["Id"]);
                products.PName = Reader["PName"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return products;
        }

        public List<AllCategorisView> GetSubCategoryByCateoryId(int categoryId)
        {
            string query = "SELECT SubCategoryId,SubCategory From AllCategorisView WHERE CategoryId=" + categoryId + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<AllCategorisView> allCategorisViews = new List<AllCategorisView>();
            while (Reader.Read())
            {
                AllCategorisView allCategorisView = new AllCategorisView();
                allCategorisView.SubCategoryId = Convert.ToInt32(Reader["SubCategoryId"]);
                allCategorisView.SubCategory = Reader["SubCategory"].ToString();

                allCategorisViews.Add(allCategorisView);
            }
            Reader.Close();
            Connection.Close();
            return allCategorisViews;
        }

       
    }
}