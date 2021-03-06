using MyBank.Domain.Entities;
using MyBank.Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Infra.Data.Repository
{
    public class ContaRepository: BaseRepository<Conta, int>, IRepositoryConta
    {
        public void Save(Conta obj)
        {
            if(obj.Id == 0)
            {
                base.Insert(obj);
            }
            else
            {
                base.Update(obj, x => x.Id == obj.Id);
            }
        }

        public void Remove(int id)
        {
            base.Delete(x => x.Id == id);
        }

        public IEnumerable<Conta> Get() => base.Select();

        public Conta Get(int id) => base.Select(x => x.Id == id);
        public Conta Get(int agencia, int numConta) => base.Select(x => x.Agencia == agencia && x.NumConta == numConta);
    }
}
