using MyBank.Domain.Models;
using System.Collections.Generic;

namespace MyBank.Domain.Interfaces
{
    public interface IServiceConta
    {
        public ContaModel insert(TokenModel createConta);
        public IEnumerable<ContaModel> Recover();
        public ContaModel Recover(int id);
        public void Depositar(ConsultaContaModel contaModel);
        public void Sacar(ConsultaContaModel contaModel);
        public void Transferir(ConsultaContaModel contaModelOrigin, ConsultaContaModel contaModelDestiny);
    }
}
