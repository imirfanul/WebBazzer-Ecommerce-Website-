using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBazzer.Models;
using WebBazzer.Controllers;

using WebBazzer.BLL;
using System.IO;
using System.Data.Entity;


namespace WebBazzer.Areas.Client.Controllers
{
    public class AccountController : Controller
    {
        WebBazerEntities db = new WebBazerEntities();
        public AccountManager AccountManager;
        public AccountController()
        {
            AccountManager = new AccountManager();
        }
        public ActionResult Index()
        {
            this.GetDefaultData();

            var usr = db.Coustomers.Find(TempShpData.UserID);
            return View(usr);

        }

        //REGISTER CUSTOMER
        [HttpPost]
        public ActionResult Register(Customers cust)
        {
            
            string message = AccountManager.Save(cust);
            ViewBag.Message = message;
            ModelState.Clear();

            Session["username"] = cust.UserName;
            TempShpData.UserID = cust.Id;
            return RedirectToAction("Login", "Account");
        }

        //LOG IN
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection formColl)
        {
            string usrName = formColl["UserName"];
            string Pass = formColl["Password"];

            if (ModelState.IsValid)
            {
                var cust = (from m in db.Coustomers
                            where (m.UserName == usrName && m.Password == Pass)
                            select m).SingleOrDefault();

                if (cust != null)
                {
                    TempShpData.UserID = cust.Id;
                    Session["username"] = cust.UserName;
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }

        //LOG OUT
        public ActionResult Logout()
        {
            Session["username"] = null;
            TempShpData.UserID = 0;
            TempShpData.items = null;
            return RedirectToAction("Index", "Home");
        }

        //UPDATE CUSTOMER DATA
        [HttpPost]
        public ActionResult Update(Customers cust)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cust).State = EntityState.Modified;
                db.SaveChanges();
                Session["username"] = cust.UserName;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}