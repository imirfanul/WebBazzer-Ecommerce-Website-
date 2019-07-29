using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebBazzer.Models;

namespace WebBazzer.Gateway
{
    public  class SupplierGateway:BaseGateway
    {
        public int Save(Suppliers supplier)
        {
            
            Query = "INSERT INTO Supplier VALUES(@firstName,@lastName,@email,@age,@address,@gender,@mobileNo,@imageUrl)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@firstName", supplier.FirstName);
            Command.Parameters.AddWithValue("@lastName", supplier.LastName);
            Command.Parameters.AddWithValue("@email", supplier.Email);
            Command.Parameters.AddWithValue("@age", supplier.Age);    
            Command.Parameters.AddWithValue("@address", supplier.Address);
            Command.Parameters.AddWithValue("@gender", supplier.Gender);
            Command.Parameters.AddWithValue("@mobileNo", supplier.MobileNo);
            Command.Parameters.AddWithValue("@imageUrl", supplier.ImageUrl);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsNameExsists(string email)
        {

            Query = "SELECT * FROM Supplier WHERE Email='" + email + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }

        public Suppliers GetSupplierById(int supplierId)
        {
            Query = "SELECT * FROM Supplier WHERE Id = " + supplierId;
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Suppliers supplier = null;
            if (Reader.HasRows)
            {
                supplier = new Suppliers();
                supplier.Id = Convert.ToInt32(Reader["Id"]);
                supplier.FirstName = Reader["FirstName"].ToString();
                supplier.LastName = Reader["LastName"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return supplier;
        }

        public List<Suppliers> GetAllSupplier()
        {

            Query = "SELECT * FROM Supplier";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Suppliers> supplierList = new List<Suppliers>();

            while (Reader.Read())
            {
                Suppliers supplier = new Suppliers();
                supplier.Id = Convert.ToInt32(Reader["Id"]);
                supplier.FirstName = Reader["FirstName"].ToString();
                supplier.LastName = Reader["LastName"].ToString();
                supplier.Email = Reader["Email"].ToString();
                supplier.Age = Convert.ToInt32(Reader["Age"]);
                supplier.Address = Reader["Address"].ToString();
                supplier.Gender = Reader["Gender"].ToString();
                supplier.MobileNo =Reader["MobileNo"].ToString();
                supplier.ImageUrl = Reader["ImageUrl"].ToString();
                supplierList.Add(supplier);

            }
            return supplierList;
        }

        public int UpdateById(Supplier supplier)
        {
            string query = "UPDATE  Supplier SET FirstName=@firstName,LastName=@lastName,Email=@email,Age=@age,Address=@address,Gender=@gender,MobileNo=@mobileNo,ImageUrl=@imageUrl WHERE Id=@id";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@firstName", supplier.FirstName);
            Command.Parameters.AddWithValue("@lastName", supplier.LastName);
            Command.Parameters.AddWithValue("@email", supplier.Email);
            Command.Parameters.AddWithValue("@age", supplier.Age);
            Command.Parameters.AddWithValue("@address", supplier.Address);
            Command.Parameters.AddWithValue("@gender", supplier.Gender);
            Command.Parameters.AddWithValue("@mobileNo", supplier.MobileNo);
            Command.Parameters.AddWithValue("@imageUrl", supplier.ImageUrl);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public int DeleteById(Supplier supplier)
        {
            string query = "DELETE FROM  Supplier WHERE Id=@id";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@firstName", supplier.FirstName);
            Command.Parameters.AddWithValue("@lastName", supplier.LastName);
            Command.Parameters.AddWithValue("@email", supplier.Email);
            Command.Parameters.AddWithValue("@age", supplier.Age);
            Command.Parameters.AddWithValue("@address", supplier.Address);
            Command.Parameters.AddWithValue("@gender", supplier.Gender);
            Command.Parameters.AddWithValue("@mobileNo", supplier.MobileNo);
            Command.Parameters.AddWithValue("@imageUrl", supplier.ImageUrl);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

       
    }
}