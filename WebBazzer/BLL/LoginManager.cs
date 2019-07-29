using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using WebBazzer.Models;
using WebBazzer.Gateway;
using System.Web.Security;
using System.Data.SqlClient;

namespace WebBazzer.BLL
{
    public class LoginManager
    {
        LoginGateway LoginGateway;
        public LoginManager()
        {
            LoginGateway = new LoginGateway();
        }

        public bool IsValid(string email, string password)
        {

           return LoginGateway.IsValid(email, password);
            
        }   
    }
}