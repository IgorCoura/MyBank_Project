using MyBank.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MyBank.Domain.Interfaces
{
    public interface IRepositoryCliente
    {

        public void Remove(int id);

        public void Save(Cliente obj);

        public Cliente Get(int id);
        public Cliente Get(string cpf, string senha);
        public Cliente Get(string token);
        public IList<Cliente> Get();
    }
}
