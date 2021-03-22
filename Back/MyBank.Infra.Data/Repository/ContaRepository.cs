using MyBank.Domain.Entities;
using MyBank.Domain.Interfaces;
using MyBank.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace MyBank.Infra.Data.Repository
{
    public class ContaRepository : BaseRepository<Conta, int>, IRepositoryConta
    {
        public ContaRepository(SqlServerContext sqlContext) : base(sqlContext)
        {
        }

        public void Save(Conta obj)
        {
            if (obj.Id == 0)
            {
                base.Insert(obj);
            }
            else
            {
                base.Update(obj);
            }
        }

        public void Remove(int id)
        {
            base.Delete(id);
        }

        public IEnumerable<Conta> Get() => base.Select();
        public Conta Get(int id) => base.Select(x => x.Id == id);
        public Conta Get(string NumConta) => base.Select(p => p.NumConta == NumConta);
        public Conta Get(string agencia, string numConta) => base.Select(x => x.Agencia == agencia && x.NumConta == numConta);
        
    }
}
