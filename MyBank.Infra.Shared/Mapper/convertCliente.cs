using MyBank.Domain.Entities;
using MyBank.Domain.Models;

namespace MyBank.Infra.Shared.Mapper
{
    public static class convertCliente
    {
        public static Cliente convertToClienteEntity(this CreateCliente model) => new Cliente(0, model.Nome, model.CPF, model.DataNascimento, 0);

    }
}
