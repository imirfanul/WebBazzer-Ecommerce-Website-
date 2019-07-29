using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBazzer.Gateway;
using WebBazzer.Models;
using WebBazzer.BLL;
using System.Dynamic;
using System.Data.Entity.Core;


namespace WebBazzer.Controllers
{
    public class HomeController : Controller
    {
        WebBazerEntities db = new WebBazerEntities();
       
        public ActionResult Index()
        {
            //ViewBag.MenProduct = HomeManager.GetMenProduct();

            ViewBag.MenProduct = db.Products.Where(x => x.Category.CName.Contains("Men's Wear")).ToList();
            ViewBag.WomenProduct = db.Products.Where(x => x.Category.CName.Contains("Women'S Wear")).ToList();
            ViewBag.ElectronicDevices = db.Products.Where(x => x.Category.CName.Contains("Electronic Devices")).ToList();
            ViewBag.ElectronicAccessories = db.Products.Where(x => x.Category.CName.Contains("Electronic Accessories")).ToList();
            ViewBag.HomeAppliance = db.Products.Where(x => x.Category.CName.Contains("Home Appliance")).ToList();
            ViewBag.HealthBeauty = db.Products.Where(x => x.Category.CName.Contains("Health & Beauty")).ToList();
            ViewBag.Slider = db.genMainSliders.ToList();
            ViewBag.PromoRight = db.genPromoRights.ToList();
            this.GetDefaultData();
            
            return View();
        }

      
    }
}