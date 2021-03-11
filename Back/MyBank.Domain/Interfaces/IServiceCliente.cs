using MyBank.Domain.Entities;
using MyBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Interfaces
{
    public interface IServiceCliente
    {
        public Cliente Insert(CreateClienteModel inCliente);

        public IEnumerable<Cliente> RecoverAll();
        public Cliente Recover(int id);
        public Cliente Recover(string cpf);

        public void Delete(int id);
    }
}
