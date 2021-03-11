using MyBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Interfaces
{
    public interface IServiceConta
    {
        public ReturnContaModel insert(CreateContaModel createConta);
        public IEnumerable<ReturnContaModel> Recover();
        public ReturnContaModel Login(int clienteId, string senha);
        public ReturnContaModel Recover(int agencia, int numConta);
        public void Depositar(TransferContaModel contaModel, double valor);
        public bool Sacar(TransferContaModel contaModel, double valor);
        public bool Transferir(TransferContaModel contaModelOrigin, TransferContaModel contaModelDestiny, double valor);
    }
}
