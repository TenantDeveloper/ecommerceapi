using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ecommerceServices.ViewModel
{
    public class ProductVm
    {
        [Required(ErrorMessage ="product name is required")]
        public string Product_Name { get; set; }
        [Required(ErrorMessage ="price is required")]
        public decimal Product_Price { get; set; }
        [Required(ErrorMessage ="product description is null")]
        public string Product_Description { get; set; }
        [Range(1,99,ErrorMessage ="range of discount between 1 to 99")]
       
        public Nullable<byte> Product_Discount { get; set; }
        public Nullable<int> Quantity_In_Stock { get; set; }
        public Nullable<int> Pecies_Per_Unit { get; set; }
        public Nullable<int> Unit_Weight { get; set; }
        public int Category_Id { get; set; }
    }
}