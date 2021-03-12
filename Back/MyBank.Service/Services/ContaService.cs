using MyBank.Domain;
using MyBank.Domain.Entities;
using MyBank.Domain.Interfaces;
using MyBank.Domain.Models;
using MyBank.Infra.Shared.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using MyBank.Infra.Shared.Mapper;

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
            if (cliente != null)
            {
                Conta conta = createConta.ConvertToEntity(cliente);
                _repositoryConta.Save(conta);
                return conta.ConvertToReturnModel();
            }
            else
            {
                throw new Exception("Cliente is null");
            }

        }

        public IEnumerable<ReturnContaModel> Recover()
        {
            IEnumerable<Conta> contas = _repositoryConta.Get();
            return contas.ConvertToReturnModel();
        }

        public ReturnContaModel Recover(ConsultaContaModel contaModel)
        {
            return _repositoryConta.Get(contaModel.Agencia, contaModel.NumConta).ConvertToReturnModel(); ;
        }
        private Conta RecoverConta(int agencia, int numConta)
        {
            return _repositoryConta.Get(agencia, numConta);
        }

        public ReturnContaModel Login(int clienteId, string senha)
        {
            return _repositoryConta.Get(clienteId, senha).ConvertToReturnModel();
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
