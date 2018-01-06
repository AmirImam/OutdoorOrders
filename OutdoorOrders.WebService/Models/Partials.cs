using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OutdoorOrders.WebService.Models
{
    public partial class Orders
    {
        public string SalespersonName
        {
            get
            {
                OrdersEntities db = new OrdersEntities();
                string name = db.Salespersons.Where(f => f.SalespersonID == this.SalespersonID).FirstOrDefault().SalespersonName;
                return name;

            }
        }
        public string CustomerBranchName
        {
            get
            {
                OrdersEntities db = new OrdersEntities();
                var model = db.CustomersBranches.Where(f => f.CustomerBranchID == this.CustomerBranchID).FirstOrDefault();
                this.CustomerName = model.CustomerName;
                string name = model.BranchName;
                return name;
            }
        }
        public string CustomerName { get; private set; }
    }
    public partial class CustomersBranches
    {
        public string CustomerName
        {
            get
            {
                string name = new OrdersEntities().Customers.Where(f => f.CustomerID == this.CustomerID).FirstOrDefault().CustomerName;
                return name;
            }
        }
    }
    public partial class Products
    {
        public string CategoryName
        {
            get
            {
                OrdersEntities db = new OrdersEntities();
                string name = db.ProductsCategories.Where(f => f.CategoryID == this.CategoryID).FirstOrDefault().CategoryName;
                return name;
            }
        }
    }
    public partial class ProductsCategories
    {
        public string ParentName
        {
            get
            {
                OrdersEntities db = new OrdersEntities();
                string name = db.ProductsCategories.Where(f => f.CategoryID == this.ParentID).FirstOrDefault().CategoryName;
                return name;
            }
        }
    }
}