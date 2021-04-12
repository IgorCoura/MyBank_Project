using MyBank.Domain.Models;
using System.Collections.Generic;

namespace MyBank.Domain.Interfaces
{
    public interface IServiceConta
    {
        public ContaModel insert(TokenModel createConta);
        public void delete(DeleteContaModel contaModel);
        public IEnumerable<ContaModel> recover();
        public ContaModel recover(int id);
        public void depositar(ConsultaContaModel contaModel);
        public void sacar(ConsultaContaModel contaModel);
        public void transferir(ConsultaContaModel contaModelOrigin, ConsultaContaModel contaModelDestiny);
    }
}
