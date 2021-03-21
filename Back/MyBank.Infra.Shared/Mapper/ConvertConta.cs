using MyBank.Domain.Entities;
using MyBank.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyBank.Infra.Shared.Mapper
{
    public static class ConvertConta
    {
        public static Conta ConvertToEntity(this CreateContaModel model) => 
            new Conta(0, model.Agencia, model.NumConta);
        public static ReturnContaModel ConvertToReturnModel(this Conta entity) => 
            new ReturnContaModel(entity.Id, entity.Agencia, entity.NumConta, entity.Saldo);
        public static IEnumerable<ReturnContaModel> ConvertToReturnModel(this IEnumerable<Conta> entitys) =>
            new List<ReturnContaModel>(entitys.Select(e => new ReturnContaModel(e.Id, e.Agencia, e.NumConta, e.Saldo)));
    }
}
