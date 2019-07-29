using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBazzer.Models;
using WebBazzer.Gateway;

    public class ProductManager
    {
         private ProductGateway ProductGateway;
         public ProductManager()
         {
             ProductGateway = new ProductGateway();
         }
        public string Save(Products products)
        {


            if (ProductGateway.IsNameExsists(products.PName))
            {
                return "This Name Already Insert";
            }
            else
            {
                int rowAffect = ProductGateway.Save(products);
                if (rowAffect > 0)
                {
                    return "Save Successfully";
                }
                else
                {
                    return "Save Failed";
                }
            }
        }

        public Products GetProductById(int products)
        {
            return ProductGateway.GetProductsById(products);
        }
        public List<Products> GetAllProducts()
        {
            return ProductGateway.GetAllProducts();
        }

        public List<SelectListItem> GetSelectListItemsForDropdown()
        {
            List<Products> products = GetAllProducts();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });
            foreach (Products product in products)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = product.PName;
                selectListItem.Value = product.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        public Products GetProductsNameById(string productName)
        {
            return ProductGateway.GetProductsNameById(productName);
        }
        public List<AllCategorisView> GetSubCategoryByCateoryId(int categoryId)
        {
            return ProductGateway.GetSubCategoryByCateoryId(categoryId);
        }

       

    }
