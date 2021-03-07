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
        IRepositoryConta repositoryConta;

        public ContaService(IRepositoryConta repositoryConta)
        {
            this.repositoryConta = repositoryConta;
        }

        public bool insert(CreateContaModel createConta)
        {
            try
            {
                Conta conta = createConta.ConvertToEntity();
                repositoryConta.Save(conta);
                return true;
            }
            catch(Exception e)
            {
                ExceptionCatcher.add(e);
                return false;
            }            
        }

        public IEnumerable<ReturnContaModel> Recover()
        {
            IEnumerable<Conta> contas = repositoryConta.Get();
            return contas.ConvertToReturnModel();
        }

        public ReturnContaModel Recover(int agencia, int numConta, string senha)
        {
            Conta contas = repositoryConta.Get(agencia, numConta, senha);
            return contas.ConvertToReturnModel();
        }

    }
}
