using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBazzer.Models;
using System.Data.SqlClient;
namespace WebBazzer.Gateway

{
    public class SubCategoryGateway:BaseGateway
    {
        public int Save(SubCategorys subCategory)
        {
            Query = "INSERT INTO SubCategory VALUES(@categoryId,@name)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@categoryId", subCategory.CategoryId);
            Command.Parameters.AddWithValue("@name", subCategory.SName);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsNameExsists(string name)
        {

            Query = "SELECT * FROM SubCategory WHERE SName='" + name + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }

        public List<SubCategorys> GetSubCategoryById(int subCategoryId)
        {
            Query = "SELECT * FROM SubCategory WHERE Id = " + subCategoryId;
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            List<SubCategorys> subCategories=new List<SubCategorys>();
            
            if (Reader.HasRows)
            {
                SubCategorys subCategory = new SubCategorys();
                subCategory.Id = Convert.ToInt32(Reader["Id"]);
                subCategory.SName = Reader["SName"].ToString();
                subCategories.Add(subCategory);
            }
            Reader.Close();
            Connection.Close();
            return subCategories;
        }
        public List<SubCategorys> GetAllSubCategories()
        {

            Query = "SELECT * FROM AllCategorisView";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<SubCategorys> subCategoryList = new List<SubCategorys>();

            while (Reader.Read())
            {
                SubCategorys subCategory = new SubCategorys();
                subCategory.Id = Convert.ToInt32(Reader["SubCategoryId"]);
                subCategory.SName = Reader["SubCategory"].ToString();
                subCategory.Category = Reader["Category"].ToString();


                subCategoryList.Add(subCategory);
            }
            Connection.Close();
            return subCategoryList;
        }

        public SubCategorys GeSubCategoryNameById(string subCategoryName)
        {
            Query = "SELECT Id,Name FROM SubCategory WHERE SName = " + subCategoryName;
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            SubCategorys subCategory = null;
            if (Reader.HasRows)
            {
                subCategory = new SubCategorys();
                subCategory.Id = Convert.ToInt32(Reader["Id"]);
                subCategory.SName = Reader["SName"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return subCategory;
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