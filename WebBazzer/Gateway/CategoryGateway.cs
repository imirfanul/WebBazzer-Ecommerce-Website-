using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBazzer.Models;
using System.Data.SqlClient;
namespace WebBazzer.Gateway
{
    public class CategoryGateway:BaseGateway
    {
        public int Save(Categorys category)
        {
            Query = "INSERT INTO Category VALUES(@name)";
            Command = new SqlCommand(Query, Connection);
           
            Command.Parameters.AddWithValue("@name", category.CName);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsNameExsists(string name)
        {

            Query = "SELECT * FROM Category WHERE CName='" + name + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }

        public Categorys GetCategoryById(int categoryId)
        {
            Query = "SELECT * FROM Category WHERE Id = " + categoryId;
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Categorys category = null;
            if (Reader.HasRows)
            {
                category = new Categorys();
                category.Id = Convert.ToInt32(Reader["Id"]);
                category.CName = Reader["CName"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return category;
        }
        public List<Categorys> GetAllCategories()
        {

            Query = "SELECT * FROM Category";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Categorys> categoryList = new List<Categorys>();

            while (Reader.Read())
            {
                Categorys catetory = new Categorys();
                catetory.Id = Convert.ToInt32(Reader["Id"]);
                catetory.CName = Reader["CName"].ToString();


                categoryList.Add(catetory);
            }
            Connection.Close();
            return categoryList;
        }

        public Categorys GeCategoryNameById(string categoryName)
        {
            Query = "SELECT Id,Name FROM Category WHERE CName = " + categoryName;
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Categorys category = null;
            if (Reader.HasRows)
            {
                 category = new Categorys();
                category.Id = Convert.ToInt32(Reader["Id"]);
                category.CName = Reader["CName"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return category;
        }

        
    }
}