using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_BL.Infrastracture
{
    interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllBind();
        TEntity GetEntity(params object[] id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
