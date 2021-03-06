using Aurora.Domain.ValueTypes;
using MyBank.Domain;
using MyBank.Domain.Entities;
using MyBank.Domain.Interfaces;
using MyBank.Domain.Models;
using MyBank.Infra.Shared.Mapper;
using System;
using System.Collections.Generic;

namespace MyBank.Service.Services
{
    public class ClienteService : IServiceCliente
    {
        IRepositoryCliente repositoryCliente;

        //TODO: add Update cliente
        
        public ClienteService(IRepositoryCliente repositoryCliente)
        {
            this.repositoryCliente = repositoryCliente;
        }

        public bool Insert(CreateClienteModel createCliente)
        {           
            try
            {
                Cliente cliente = createCliente.ConvertToEntity();
                repositoryCliente.Save(cliente);
                return true;
            }

            catch (Exception e)
            {
                ExceptionCatcher.add(e);
                return false;
            }
        }

        public IEnumerable<Cliente> RecoverAll()
        {
            return repositoryCliente.Get();
        }

        public Cliente Recover(int id)
        {
            return repositoryCliente.Get(id);
        }
        public Cliente Recover(string cpf)
        {
            try
            {
                CPF input = cpf;
                return repositoryCliente.Get(input);
            }
            catch(Exception e)
            {
                ExceptionCatcher.add(new Exception("Fail in recover by CPF\nErro: "+ e.Message));
                return null;
            }
            
        }

        public void Delete(int id)
        {
            repositoryCliente.Remove(id);
        }
    }
}
