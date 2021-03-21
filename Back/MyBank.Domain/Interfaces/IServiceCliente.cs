using MyBank.Domain.Entities;
using MyBank.Domain.Models;
using System.Collections.Generic;

namespace MyBank.Domain.Interfaces
{
    public interface IServiceCliente
    {
        public ClienteModel Insert(CreateClienteModel createCliente);
        public IEnumerable<ClienteModel> RecoverAll();
        public ClienteModel Recover(int id);
        public RespostaLoginModel Login(string cpf, string senha);
        public void Delete(int id);

    }
}
