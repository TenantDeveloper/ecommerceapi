using ecommerce_BL.Infrastracture;
using ecommerce_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_UnitOfWork.Managers
{
  public  class CategoryManager:Repository<Category>
    {
        public CategoryManager(ECom_DemoEntities context):base(context)
        {

        }
    }
}
