using Aurora.Domain.ValueTypes;
using MyBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Interfaces
{
    public interface IRepositoryCliente
    {

        public void Remove(int id);

        public void Save(Cliente obj);

        public Cliente Get(int id);
        public Cliente Get(CPF cpf);

        public IList<Cliente> Get();
    }
}
