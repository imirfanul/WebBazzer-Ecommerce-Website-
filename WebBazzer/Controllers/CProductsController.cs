﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBazzer.Models;
using PagedList;
namespace WebBazzer.Controllers
{
    public class CProductsController : Controller
    {
        WebBazerEntities db = new WebBazerEntities();
        public ActionResult Index()
        {
            ViewBag.Categories = db.Categories.Select(x => x.CName).ToList();

            //ViewBag.TopRatedProducts = TopSoldProducts();
            ViewBag.RecentViewsProducts = RecentViewProducts();

            return View("Products");
        }

        //public List<TopSoldProduct> TopSoldProducts()
        //{
        //    var prodList = (from prod in db.OrderDetails
        //                    select new { prod.ProductID, prod.Quantity } into p
        //                    group p by p.ProductID into g
        //                    select new
        //                    {
        //                        pID = g.Key,
        //                        sold = g.Sum(x => x.Quantity)
        //                    }).OrderByDescending(y => y.sold).Take(9).ToList();



        //    List<TopSoldProduct> topSoldProds = new List<TopSoldProduct>();

        //    for (int i = 0; i < 9; i++)
        //    {
        //        topSoldProds.Add(new TopSoldProduct()
        //        {
        //            product = db.Products.Find(prodList[i].pID),
        //            CountSold = Convert.ToInt32(prodList[i].sold)
        //        });
        //    }
        //    return topSoldProds;
        //}

        //RECENT VIEWS PRODUCTS
        public IEnumerable<Product> RecentViewProducts()
        {
            if (TempShpData.UserID > 0)
            {
                var top3Products = (from recent in db.RecentlyViews
                                    where recent.CustomerID == TempShpData.UserID
                                    orderby recent.ViewDate descending
                                    select recent.ProductID).ToList().Take(3);

                var recentViewProd = db.Products.Where(x => top3Products.Contains(x.Id));
                return recentViewProd;
            }
            else
            {
                var prod = (from p in db.Products
                            select p).OrderByDescending(x => x.Price).Take(3).ToList();
                return prod;
            }
        }

        //ADD TO CART
        public ActionResult AddToCart(int id)
        {
            OrderDetail OD = new OrderDetail();
            OD.ProductID = id;
            int Qty = 1;
            decimal? price = db.Products.Find(id).Price;
            OD.Quantity = Qty;
            OD.UnitPrice = price;
            OD.TotalAmount = Qty * price;
            OD.Product = db.Products.Find(id);

            if (TempShpData.items == null)
            {
                TempShpData.items = new List<OrderDetail>();
            }
            TempShpData.items.Add(OD);
            AddRecentViewProduct(id);
            return Redirect(TempData["returnURL"].ToString());
        }

         //VIEW DETAILS
        public ActionResult ViewDetails(int id)
        {
            var prod = db.Products.Find(id);
            var reviews = db.Reviews.Where(x => x.ProductID == id).ToList();
            ViewBag.Reviews = reviews;
            ViewBag.TotalReviews = reviews.Count();
            ViewBag.RelatedProducts = db.Products.Where(y => y.CategoryId == prod.CategoryId).ToList();
            AddRecentViewProduct(id);

            var ratedProd=db.Reviews.Where(x => x.ProductID == id).ToList();
            int count = ratedProd.Count();
            int TotalRate =  ratedProd.Sum(x => x.Rate).GetValueOrDefault();
            ViewBag.AvgRate = TotalRate > 0 ? TotalRate / count : 0;

            this.GetDefaultData();
            return View(prod);
        }

        //WISHLIST
        public ActionResult WishList(int id)
        {
            
            Wishlist wl = new Wishlist();
            wl.ProductID = id;
            wl.CustomerID = TempShpData.UserID;

            db.Wishlists.Add(wl);
            db.SaveChanges();
            AddRecentViewProduct(id);
            ViewBag.WlItemsNo = db.Wishlists.Where(x => x.CustomerID == TempShpData.UserID).ToList().Count();
            if (TempData["returnURL"].ToString()=="/")
            {
                return RedirectToAction("Index","Home");
            }
            return Redirect(TempData["returnURL"].ToString());
        }

        //ADD RECENT VIEWS PRODUCT IN DB
        public void AddRecentViewProduct(int pid)
        {
            if (TempShpData.UserID > 0)
            {
                RecentlyView Rv = new RecentlyView();
                Rv.CustomerID = TempShpData.UserID;
                Rv.ProductID = pid;
                Rv.ViewDate = DateTime.Now;
                db.RecentlyViews.Add(Rv);
                db.SaveChanges();
            }
        }

        //ADD REVIEWS ABOUT PRODUCT
        public ActionResult AddReview(int productID, FormCollection getReview)
        {

            Review r = new Review();
            r.CustomerID = TempShpData.UserID;
            r.ProductID = productID;
            r.Name = getReview["name"];
            r.Email = getReview["email"];
            r.Review1 = getReview["message"];
            r.Rate = Convert.ToInt32(getReview["rate"]);
            r.DateTime = DateTime.Now;

            db.Reviews.Add(r);
            db.SaveChanges();
            return RedirectToAction("ViewDetails/" + productID + "");

        }


        public ActionResult Products(int? subCatID)
        {
            ViewBag.Categories = db.Categories.Select(x => x.CName).ToList();
            var prods = db.Products.Where(y => y.SubCategoryId == subCatID).ToList();
            return View(prods);
        }

        //GET PRODUCTS BY CATEGORY
        public ActionResult GetProductsByCategory(string categoryName, int? page)
        {
            ViewBag.Categories = db.Categories.Select(x => x.CName).ToList();
            //ViewBag.TopRatedProducts = TopSoldProducts();
         
            ViewBag.RecentViewsProducts = RecentViewProducts();

            var prods = db.Products.Where(x => x.SubCategory.SName == categoryName).ToList();
            return View("Products", prods.ToPagedList(page ?? 1, 9));
        }

        //SEARCH BAR
        public ActionResult Search(string product,int? page)
        {
            ViewBag.Categories = db.Categories.Select(x => x.CName).ToList();
            //ViewBag.TopRatedProducts = TopSoldProducts();
          
            ViewBag.RecentViewsProducts = RecentViewProducts();

            List<Product> products;
            if (!string.IsNullOrEmpty(product))
            {
                products = db.Products.Where(x => x.PName.StartsWith(product)).ToList();
            }
            else
            {
                products = db.Products.ToList();
            }
            return View("Products", products.ToPagedList(page ?? 1,6));
        }

        public JsonResult GetProducts(string term)
        {
            List<string> prodNames = db.Products.Where(x => x.PName.StartsWith(term)).Select(y => y.PName).ToList();
            return Json(prodNames, JsonRequestBehavior.AllowGet);

        }
        public ActionResult FilterByPrice(int minPrice,int maxPrice,int? page)
        {
            ViewBag.Categories = db.Categories.Select(x => x.CName).ToList();
            //ViewBag.TopRatedProducts = TopSoldProducts();

            ViewBag.RecentViewsProducts = RecentViewProducts();
            ViewBag.filterByPrice = true;
           var filterProducts= db.Products.Where(x => x.Price >= minPrice && x.Price <= maxPrice).ToList();
           return View("Products", filterProducts.ToPagedList(page ?? 1, 9));
        }

        public ActionResult GetProductsBySubCategory(string scategoryName, int? page)
        {
            ViewBag.Categories = db.Categories.Select(x => x.CName).ToList();
            //ViewBag.TopRatedProducts = TopSoldProducts();

            ViewBag.RecentViewsProducts = RecentViewProducts();

            var prods = db.Products.Where(x => x.SubCategory.SName == scategoryName).ToList();
            return View("Products", prods.ToPagedList(page ?? 1, 9));
        }


    }
}