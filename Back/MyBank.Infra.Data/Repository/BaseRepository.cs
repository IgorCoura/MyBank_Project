using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Infra.Data.Repository
{
    public class BaseRepository<TEntity, TKeyType>
    {
        //TODO: Interligar com um banco de dados
        List<TEntity> list = new List<TEntity>();

        protected virtual void Insert(TEntity obj)
        {            
            list.Add(obj);
        }

        protected virtual void Update(TEntity obj, Predicate<TEntity> p)
        {
            list.Insert(list.FindIndex(p), obj);
        }

        protected virtual void Delete(Predicate<TEntity> p)
        {
            list.Remove(list.Find(p));
        }

        protected virtual void SaveChanges()
        {

        }

        protected virtual IList<TEntity> Select() => list;

        protected virtual TEntity Select(Predicate<TEntity> p) => list.Find(p);
    }
}
