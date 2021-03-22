using MyBank.Domain.Entities;
using MyBank.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyBank.Infra.Shared.Mapper
{
    public static class ConvertConta
    {

        public static ContaModel ConvertToReturnModel(this Conta entity) => 
            new ContaModel(entity.Id, entity.Agencia, entity.NumConta, entity.Saldo);
        public static IEnumerable<ContaModel> ConvertToReturnModel(this IEnumerable<Conta> entitys) =>
            new List<ContaModel>(entitys.Select(e => new ContaModel(e.Id, e.Agencia, e.NumConta, e.Saldo)));
    }
}
