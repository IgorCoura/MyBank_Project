using MyBank.Domain.Entities;
using MyBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Infra.Shared.Mapper
{
    public static class ConvertConta
    {
        public static Conta ConvertToEntity(this CreateContaModel model) => 
            new Conta(0, model.Cliente, model.Agencia, model.NumConta, model.Senha, 0);
        public static ReturnContaModel ConvertToReturnModel(this Conta entity) => 
            new ReturnContaModel(entity.Id, entity.Cliente, entity.Agencia, entity.NumConta, entity.Saldo);
        public static IEnumerable<ReturnContaModel> ConvertToReturnModel(this IEnumerable<Conta> entitys) =>
            new List<ReturnContaModel>(entitys.Select(e => new ReturnContaModel(e.Id, e.Cliente, e.Agencia, e.NumConta, e.Saldo)));
    }
}
