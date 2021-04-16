using MyBank.Domain.Entities;
using MyBank.Domain.Models;
using System.Collections.Generic;

namespace MyBank.Domain.Interfaces
{
    public interface IServiceCliente
    {
        public ClienteModel Insert(CreateClienteModel createCliente);
        public ClienteModel Recover(TokenModel token);
        public ReturnLoginModel Login(LoginModel loginModel);

    }
}
