using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBazzer.Models;
using System.Web.Security;
using System.Data.SqlClient;

namespace WebBazzer.Gateway
{
    public class LoginGateway:BaseGateway
    {
        public bool IsValid(string email, string password)
        {

            string query = "SELECT Email,Password FROM Admin WHERE Name='" + email + "',Password="+password+"";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            bool Reader = false;
            Reader =Convert.ToBoolean(Command.ExecuteReader());
            
            
            Connection.Close();
            return Reader;
            
        }   
    }
}