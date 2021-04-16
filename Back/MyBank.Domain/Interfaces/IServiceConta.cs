using MyBank.Domain.Models;
using System.Collections.Generic;

namespace MyBank.Domain.Interfaces
{
    public interface IServiceConta
    {
        public ReturnContaModel insert(TokenModel createConta);
        public void delete(ContaModel contaModel);
        public void depositar(TransacaoContaModel contaModel);
        public void sacar(TransacaoContaModel contaModel);
        public void transferir(TransferenciaContaModel contaModel);
    }
}
