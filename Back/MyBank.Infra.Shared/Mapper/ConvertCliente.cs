using MyBank.Domain.Entities;
using MyBank.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyBank.Infra.Shared.Mapper
{
    public static class ConvertCliente
    {
        public static Cliente ConvertToEntity(this CreateClienteModel model) => new Cliente(0, model.Nome, model.CPF, model.DataNascimento, model.Senha);

        public static ClienteModel ConvertToModel(this Cliente entity) => new ClienteModel(entity.Id, entity.Nome, entity.CPF.ToString(), entity.DataNascimento);
        public static IEnumerable<ClienteModel> ConvertToModel(this IEnumerable<Cliente> entitys) => new List<ClienteModel>(entitys.Select(entity => entity.ConvertToModel()));

    }
}
