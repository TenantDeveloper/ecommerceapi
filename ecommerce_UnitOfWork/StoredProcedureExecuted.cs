using ecommerce_DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_UnitOfWork
{
   public static class StoredProcedureExecutedExtenstion
    {
        private readonly static ECom_DemoEntities ctx = new ECom_DemoEntities();

        #region methods
        public static void CreateProduct(this UOW uow ,Product product) => ctx.Sp_CreateProduct(product.Product_Name, product.Product_Price, product.Product_Discount, product.Quantity_In_Stock, product.Pecies_Per_Unit, product.Unit_Weight, product.Product_Description, product.Category_Id);

        public static ObjectResult<Sp_GetProducts_Result> GetProduct(this UOW uow) => ctx.Sp_GetProducts();

        public static void UpdateProduct(this UOW uow, Product product) => ctx.Sp_UpdateProduct(product.Id, product.Product_Name, product.Product_Price, product.Product_Discount, product.Quantity_In_Stock, product.Pecies_Per_Unit, product.Unit_Weight, product.Product_Description, product.Category_Id);
        #endregion
    }
}
