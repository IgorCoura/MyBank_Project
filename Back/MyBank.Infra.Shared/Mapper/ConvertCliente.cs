using MyBank.Domain.Entities;
using MyBank.Domain.Models;

namespace MyBank.Infra.Shared.Mapper
{
    public static class ConvertCliente
    {
        public static Cliente ConvertToEntity(this CreateClienteModel model) => new Cliente(0, model.Nome, model.CPF, model.DataNascimento);

        public static ClienteModel ConvertToModel(this Cliente entity) => new ClienteModel(entity.Id, entity.Nome, entity.CPF.ToString(), entity.DataNascimento);

    }
}
