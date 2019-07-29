using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using WebBazzer.Gateway;
using WebBazzer.Models;

namespace WebBazzer.BLL
{
    public class AccountManager
    {
        public AccountGateway AccountGateway;
        public AccountManager()
        {
            AccountGateway = new AccountGateway();
        }

        public string Save(WebBazzer.Models.Customers customers)
        {


            if (AccountGateway.IsUserNameExsists(customers.UserName))
            {
                return "This UserName Already Exist!";
            }
                 if (AccountGateway.IsEmailExsists(customers.Email))
                {
                    return "This Email Already Exist!";
                }

                else
                {
                    int rowAffect = AccountGateway.Save(customers);
                    if (rowAffect > 0)
                    {
                        return "Registration Successfully";
                    }
                    else
                    {
                        return "Registration Failed";
                    }
                }
            }

        public List<Countrys> GetAllContries()
        {
            return AccountGateway.GetAllContries();
        }

        public List<SelectListItem> GetSelectListItemsForDropdown()
        {
            List<Countrys> countries = GetAllContries();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select A Country--",
                Value = ""
            });
            foreach (Countrys country in countries)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = country.CountryName;
                selectListItem.Value = country.CountryName;
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        public bool IsValid(string email, string password)
        {
            return AccountGateway.IsValid(email, password);
        }

        }
    }
