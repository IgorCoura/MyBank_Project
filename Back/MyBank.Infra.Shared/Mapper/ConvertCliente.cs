using MyBank.Domain.Entities;
using MyBank.Domain.Models;

namespace MyBank.Infra.Shared.Mapper
{
    public static class ConvertCliente
    {
        public static Cliente ConvertToEntity(this CreateClienteModel model) => new Cliente(0, model.Nome, model.CPF, model.DataNascimento, 0);

    }
}
