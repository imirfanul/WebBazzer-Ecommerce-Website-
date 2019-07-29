using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBazzer.Models;
using WebBazzer.Gateway;

namespace WebBazzer.BLL
{
    public class SupplierManager
    {
        public SupplierGateway SupplierGateway;
        public SupplierManager()
        {
            SupplierGateway = new SupplierGateway();
        }

        public string Save(WebBazzer.Models.Suppliers supplier)
        {


            if (SupplierGateway.IsNameExsists(supplier.Email))
            {
                return "This Email Already Exist!";
            }
            else
            {
                int rowAffect = SupplierGateway.Save(supplier);
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

        public WebBazzer.Models.Suppliers GetSupplierById(int supplier)
        {
            return SupplierGateway.GetSupplierById(supplier);
        }
        public List<WebBazzer.Models.Suppliers> GetAllSupplier()
        {
            return SupplierGateway.GetAllSupplier();
        }
        public int UpdateById(WebBazzer.Models.Supplier supplier)
        {
            return SupplierGateway.UpdateById(supplier);
        }

        public int DeleteById(WebBazzer.Models.Supplier supplier)
        {
            return SupplierGateway.DeleteById(supplier);
        }
    }
}