using ecommerce_DAL;
using ecommerce_UnitOfWork.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_UnitOfWork
{
   public class UOW
    {
        private readonly ECom_DemoEntities ctx = new ECom_DemoEntities();

        public ProductManager ProductManager
        {
            get
            {
                return new ProductManager(ctx);
            }
        }

        public CategoryManager CategoryManager
        {
            get
            {
                return new CategoryManager(ctx);
            }
        }

        public async Task<bool> SaveAsync()
        {
           return await ctx.SaveChangesAsync()>0?true:false;
        }

    }
}
