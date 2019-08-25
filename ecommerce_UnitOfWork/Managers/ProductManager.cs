using ecommerce_BL.Infrastracture;
using ecommerce_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_UnitOfWork.Managers
{
   public class ProductManager:Repository<Product>
    {
        private readonly ECom_DemoEntities ctx;
        public ProductManager(ECom_DemoEntities context) :base(context)
        {
           
        }

        public IEnumerable<Product> GetProductByName(string productName)
        {
           return GetAll().Where(p => string.Compare(p.Product_Name, productName) == 0);
        }
      
    }
}
