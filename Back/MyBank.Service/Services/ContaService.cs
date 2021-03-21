using MyBank.Domain.Entities;
using MyBank.Domain.Interfaces;
using MyBank.Domain.Models;
using MyBank.Infra.Shared.Mapper;
using System;
using System.Collections.Generic;


namespace MyBank.Service.Services
{
    public class ContaService : IServiceConta
    {
        private readonly IRepositoryConta _repositoryConta;
        private readonly IRepositoryCliente _repositoryCliente;
        public ContaService(IRepositoryConta repositoryConta, IRepositoryCliente repositoryCliente)
        {
            _repositoryConta = repositoryConta;
            _repositoryCliente = repositoryCliente;
        }

        public ReturnContaModel insert(CreateContaModel createConta)
        {
            var conta = createConta.ConvertToEntity();
            conta.Cliente =_repositoryCliente.Get(createConta.Token);
            _repositoryConta.Save(conta);
            return conta.ConvertToReturnModel();
        }

        public IEnumerable<ReturnContaModel> Recover()
        {
            IEnumerable<Conta> contas = _repositoryConta.Get();
            return contas.ConvertToReturnModel();
        }

        public ReturnContaModel Recover(int id)
        {
            var conta = _repositoryConta.Get(id);
            return conta.ConvertToReturnModel(); ;
        }
        private Conta RecoverConta(int agencia, int numConta)
        {
            return _repositoryConta.Get(agencia, numConta);
        }

        public virtual void Depositar(ConsultaContaModel contaModel)
        {
            Conta conta = RecoverConta(contaModel.Agencia, contaModel.NumConta);
            conta.Saldo += contaModel.Valor;
            _repositoryConta.Save(conta);
        }

        public virtual void Sacar(ConsultaContaModel contaModel)
        {
            Conta conta = RecoverConta(contaModel.Agencia, contaModel.NumConta);
            conta.Saldo -= contaModel.Valor;
            if (conta.Saldo >= 0)
            {
                _repositoryConta.Save(conta);
            }
            else
            {
                throw new Exception("Saldo insuficiente.");
            }


        }

        public virtual void Transferir(ConsultaContaModel contaModelOrigin, ConsultaContaModel contaModelDestiny)
        {
            Sacar(contaModelOrigin);
            contaModelDestiny.Valor = contaModelOrigin.Valor;
            Depositar(contaModelDestiny);
        }
    }
}
