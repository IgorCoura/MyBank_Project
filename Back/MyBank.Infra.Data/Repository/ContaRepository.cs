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

        public void Remove(string agencia, string numConta)
        {
            base.Delete(x => x.Agencia == agencia && x.NumConta == numConta);
        }

        public IEnumerable<Conta> Get() => base.SelectList();
        public IEnumerable<Conta> GetList(int clinteId) => base.SelectList(x => x.ClienteId == clinteId);
        public Conta Get(int id) => base.Select(x => x.Id == id);
        public Conta Get(string agencia, string numConta) => base.Select(x => x.Agencia == agencia && x.NumConta == numConta);
        
    }
}
