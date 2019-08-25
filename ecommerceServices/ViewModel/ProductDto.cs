using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerceServices.ViewModel
{
    public class ProductDto
    {
        public Nullable<int> Id { get; set; }
        public string Product_Name { get; set; }
        public Nullable<decimal> Product_Price { get; set; }
        public string Product_Description { get; set; }
        public Nullable<byte> Product_Discount { get; set; }
        public Nullable<int> Quantity_In_Stock { get; set; }
        public Nullable<int> Unit_Weight { get; set; }
        public Nullable<int> Category_Id { get; set; }
        public string Category_Name { get; set; }
    }
}