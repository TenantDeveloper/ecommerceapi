using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_BL.Infrastracture
{
    public class Repository<TEntity> : IRepository<TEntity>
         where TEntity : class
    {
        #region properties
        private DbContext _ctx;
        private DbSet<TEntity> _set;
        #endregion
        #region Constructor
        public Repository(DbContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<TEntity>();
        }
        #endregion
        #region methods

        public void Add(TEntity entity)
        {
            _set.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _set.Remove(entity);
        }

        public IQueryable<TEntity> GetAll() => _set;


        public IEnumerable<TEntity> GetAllBind() => GetAll().ToList();

        public TEntity GetEntity(params object[] id) => _set.Find(id);

        public void Update(TEntity entity)
        {
            _set.Attach(entity);
            _ctx.Entry(entity).State = EntityState.Modified;
        }
        #endregion
    }
}
