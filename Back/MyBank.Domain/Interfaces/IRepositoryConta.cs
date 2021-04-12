using MyBank.Domain.Entities;
using System.Collections.Generic;

namespace MyBank.Domain.Interfaces
{
    public interface IRepositoryConta
    {
        public void Save(Conta obj);

        public void Remove(string agencia, string numConta);

        public IEnumerable<Conta> Get();
        public IEnumerable<Conta> GetList(int clinteId);
        public Conta Get(int id);
        public Conta Get(string agencia, string numConta);
    }
}
