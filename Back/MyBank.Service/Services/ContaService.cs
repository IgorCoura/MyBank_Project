using MyBank.Domain;
using MyBank.Domain.Entities;
using MyBank.Domain.Interfaces;
using MyBank.Domain.Models;
using MyBank.Infra.Shared.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Service.Services
{
    public class ContaService : IServiceConta
    {
        private readonly IRepositoryConta _repositoryConta;
        private readonly IServiceCliente _serviceCliente;
        public ContaService(IRepositoryConta repositoryConta, IServiceCliente serviceCliente)
        {
            _repositoryConta = repositoryConta;
            _serviceCliente = serviceCliente;
        }

        public ReturnContaModel insert(CreateContaModel createConta)
        {
            var cliente = _serviceCliente.Recover(createConta.Cpf);
            Conta conta = createConta.ConvertToEntity(cliente);
            _repositoryConta.Save(conta);
            return conta.ConvertToReturnModel();
        }

        public IEnumerable<ReturnContaModel> Recover()
        {
            IEnumerable<Conta> contas = _repositoryConta.Get();
            return contas.ConvertToReturnModel();
        }

        public ReturnContaModel Login(int clienteId, string senha)
        {
            return _repositoryConta.Get(clienteId, senha).ConvertToReturnModel();
        }
        private Conta RecoverConta(int agencia, int numConta)
        {
            return _repositoryConta.Get(agencia, numConta);
        }

        public ReturnContaModel Recover(int agencia, int numConta)
        {
            return _repositoryConta.Get(agencia, numConta).ConvertToReturnModel();
        }

        public void Depositar(TransferContaModel contaModel, double valor)
        {
            Conta conta = RecoverConta(contaModel.Agencia, contaModel.NumConta);
            conta.Saldo += valor;
            _repositoryConta.Save(conta);
        }

        public bool Sacar(TransferContaModel contaModel, double valor)
        {
            Conta conta = RecoverConta(contaModel.Agencia, contaModel.NumConta);
            conta.Saldo -= valor;
            _repositoryConta.Save(conta);
            return true;
        }

        public bool Transferir(TransferContaModel contaModelOrigin, TransferContaModel contaModelDestiny, double valor)
        {
            if (Sacar(contaModelOrigin, valor))
            {
                Depositar(contaModelDestiny, valor);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
