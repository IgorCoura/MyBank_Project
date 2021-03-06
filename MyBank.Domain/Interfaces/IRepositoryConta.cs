using MyBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Interfaces
{
    public interface IRepositoryConta
    {
        public void Save(Conta obj);

        public void Remove(int id);

        public IEnumerable<Conta> Get();

        public Conta Get(int id);
        public Conta Get(int agencia, int numConta);
    }
}
