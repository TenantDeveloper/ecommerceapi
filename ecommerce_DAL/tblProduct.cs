//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ecommerce_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProduct
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public Nullable<byte> productDiscount { get; set; }
        public Nullable<int> quanitity { get; set; }
        public Nullable<int> pecies { get; set; }
        public Nullable<int> unitWeight { get; set; }
        public string productDescription { get; set; }
        public int categoryId { get; set; }
    }
}
