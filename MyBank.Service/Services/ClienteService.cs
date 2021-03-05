using MyBank.Domain.Entities;
using MyBank.Domain.Models;
using MyBank.Infra.Shared.Mapper;
using System;


namespace MyBank.Service.Services
{
    public class ClienteService
    {
        public bool CriarCliente(CreateCliente inCliente)
        {           
            try
            {
                Cliente cliente = inCliente.convertToClienteEntity();
                //_repositoryCliente.save(cliente);
                return true;
            }
            catch (Exception e)
            {
                //TODO: add exception em uma lista
                return false;
            }
        }
    }
}
