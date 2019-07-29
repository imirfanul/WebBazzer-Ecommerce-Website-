using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBazzer.Models;

namespace WebBazzer.Gateway
{
    public class AccountGateway:BaseGateway
    {
        public int Save(Customers customer)
        {

            Query = "INSERT INTO Coustomer VALUES(@firstName,@lastName,@userName,@email,@password,@gender,@mobileNo,@country,@city,@address,@postalCode)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@firstName", customer.FirstName);
            Command.Parameters.AddWithValue("@lastName", customer.LastName);
            Command.Parameters.AddWithValue("@userName", customer.UserName);
            Command.Parameters.AddWithValue("@email", customer.Email);
            Command.Parameters.AddWithValue("@password", customer.Password);  
            Command.Parameters.AddWithValue("@gender", customer.Gender);
            Command.Parameters.AddWithValue("@mobileNo", customer.MobileNo);
            Command.Parameters.AddWithValue("@country", customer.Country);
            Command.Parameters.AddWithValue("@city", customer.City);
            Command.Parameters.AddWithValue("@address", customer.Address);
            Command.Parameters.AddWithValue("@postalCode", customer.PostalCode);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsEmailExsists(string email)
        {

            Query = "SELECT * FROM Coustomer WHERE Email='" + email + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }

        public bool IsUserNameExsists(string userName)
        {

            Query = "SELECT * FROM Coustomer WHERE UserName='" + userName + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }


        public List<Countrys> GetAllContries()
        {

            Query = "SELECT * FROM Country";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Countrys> countryList = new List<Countrys>();

            while (Reader.Read())
            {
                Countrys country = new Countrys();
                country.Id = Convert.ToInt32(Reader["Id"]);
                country.CountryName = Reader["Country"].ToString();


                countryList.Add(country);
            }
            Connection.Close();
            return countryList;
        }
        public bool IsValid(string email, string password)
        {

            string query = "SELECT Email,Password FROM Coustomer WHERE Email='" + email + "',Password=" + password + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            bool Reader = false;
            Reader = Convert.ToBoolean(Command.ExecuteReader());


            Connection.Close();
            return Reader;

        }   

    }
}