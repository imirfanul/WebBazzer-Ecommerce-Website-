using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBazzer.Models;
using WebBazzer.Gateway;

namespace WebBazzer.BLL
{
    public  class CategoryManager
    {
        private CategoryGateway CategoryGateway;
        public CategoryManager()
        {
            CategoryGateway = new CategoryGateway();
        }

        public string Save(WebBazzer.Models.Categorys category)
        {


            if (CategoryGateway.IsNameExsists(category.CName))
            {
                return "This Name Already Insert";
            }
            else
            {
                int rowAffect = CategoryGateway.Save(category);
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
       
        public Categorys GetCategoryById(int category)
        {
            return CategoryGateway.GetCategoryById(category);
        }
        public List<Categorys> GetAllCategories()
        {
            return CategoryGateway.GetAllCategories();
        }

        public List<SelectListItem> GetSelectListItemsForDropdown()
        {
            List<Categorys> categories = GetAllCategories();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select A Category--",
                Value = ""
            });
            foreach (Categorys category in categories)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = category.CName;
                selectListItem.Value = category.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        public Categorys GetCategoryNameById(string categoryName)
        {
            return CategoryGateway.GeCategoryNameById(categoryName);
        }
    }
}