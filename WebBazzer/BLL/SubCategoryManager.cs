using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBazzer.Models;
using WebBazzer.Gateway;

namespace WebBazzer.BLL
{
    public class SubCategoryManager
    {
        private SubCategoryGateway SubCategoryGateway;
        public SubCategoryManager()
        {
            SubCategoryGateway = new SubCategoryGateway();
        }

        public string Save(SubCategorys subCategory)
        {


            if (SubCategoryGateway.IsNameExsists(subCategory.SName))
            {
                return "This Name Already Insert";
            }
            else
            {
                int rowAffect = SubCategoryGateway.Save(subCategory);
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
       
        public List<SubCategorys> GetSubCategoryById(int subCategoryId)
        {
            return SubCategoryGateway.GetSubCategoryById(subCategoryId);
        }
        public List<SubCategorys> GetAllSubCategories()
        {
            return SubCategoryGateway.GetAllSubCategories();
        }

        public List<SelectListItem> GetSelectListItemsForDropdown()
        {
            List<SubCategorys> subCategories = GetAllSubCategories();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select A Sub Category--",
                Value = ""
            });
            foreach (SubCategorys subCategory in subCategories)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = subCategory.SName;
                selectListItem.Value = subCategory.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        public WebBazzer.Models.SubCategorys GetSubCategoryNameById(string subCategoryName)
        {
            return SubCategoryGateway.GeSubCategoryNameById(subCategoryName);
        }

        public List<AllCategorisView> GetSubCategoryByCateoryId(int categoryId)
        {
            return SubCategoryGateway.GetSubCategoryByCateoryId(categoryId);
        }


        
    }
}