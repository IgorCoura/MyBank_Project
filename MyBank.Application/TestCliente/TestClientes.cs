using MyBank.Domain.Interfaces;
using MyBank.Domain.Models;
using MyBank.Domain.Entities;
using MyBank.Infra.Data.Repository;
using MyBank.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Application.TestCliente
{
    public class TestClientes
    {
        IRepositoryCliente repo;
        IServiceCliente service;
        public TestClientes(IRepositoryCliente repor, IServiceCliente cc)
        {
            repo = repor;
            service = cc;

            service.Insert(new CreateClienteModel("Bruno", "048.791.300-01", "20/03/1998"));
            service.Insert(new CreateClienteModel("Jose", "453.200.670-89", "20/03/1995"));
            service.Insert(new CreateClienteModel("Laysa", "960.182.890-75", "20/03/1991"));
            service.Insert(new CreateClienteModel("Mikaela", "127.899.900-00", "20/03/1993"));
            service.Insert(new CreateClienteModel("Larissa", "036.787.760-00", "20/03/1999"));
            service.Insert(new CreateClienteModel("Edson", "449.221.710-02", "20/03/1994"));
        }

        public void ViewAll()
        {
            Console.WriteLine("\nRecoverAll");
            List<Cliente> list = (List<Cliente>)service.RecoverAll();
            foreach (Cliente cc in list)
            {
                Console.WriteLine(cc.Id);
                Console.WriteLine(cc.Nome);
                Console.WriteLine(cc.CPF + "\n");
            }
        }
        
        public void View(int id)
        {
            Cliente c = service.Recover(id);
            if (c != null)
            {
                Console.WriteLine("\nRecover by ID");
                Console.WriteLine(c.Id);
                Console.WriteLine(c.Nome);
                Console.WriteLine(c.CPF + "\n");
            }
        }

        public void View(string cpf)
        {
            Cliente c = service.Recover(cpf);
            if (c != null)
            {
                Console.WriteLine("\nRecover by CPF");
                Console.WriteLine(c.Id);
                Console.WriteLine(c.Nome);
                Console.WriteLine(c.CPF + "\n");
            }
        }

    }
}
