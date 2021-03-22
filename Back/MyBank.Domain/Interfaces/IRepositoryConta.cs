using MyBank.Domain.Entities;
using System.Collections.Generic;

namespace MyBank.Domain.Interfaces
{
    public interface IRepositoryConta
    {
        public void Save(Conta obj);

        public void Remove(int id);

        public IEnumerable<Conta> Get();

        public Conta Get(int id);
        public Conta Get(string numConta);
        public Conta Get(string agencia, string numConta);
    }
}
