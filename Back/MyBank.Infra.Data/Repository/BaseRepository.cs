using MyBank.Domain.Entities;
using MyBank.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBank.Infra.Data.Repository
{
    public class BaseRepository<TEntity, TKeyType> where TEntity: BaseEntity<TKeyType>
    {
        protected readonly SqlServerContext _sqlContext;

        public BaseRepository(SqlServerContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        protected virtual void Insert(TEntity obj)
        {
            _sqlContext.Set<TEntity>().Add(obj);
            _sqlContext.SaveChanges();
        }

        protected virtual void Update(TEntity obj)
        {
            _sqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sqlContext.SaveChanges();
        }

        protected virtual void Delete(TKeyType id)
        {
            _sqlContext.Set<TEntity>().Remove(_sqlContext.Set<TEntity>().Find(id));
            _sqlContext.SaveChanges();
        }

        protected virtual IList<TEntity> Select() =>
            _sqlContext.Set<TEntity>().ToList();

        protected virtual TEntity Select(Func<TEntity, bool> p) =>
            _sqlContext.Set<TEntity>().Single(p);

    }
}
