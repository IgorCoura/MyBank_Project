using MyBank.Application.Display;
using MyBank.Application.TestCliente;
using MyBank.Domain;
using MyBank.Domain.Entities;
using MyBank.Domain.Interfaces;
using MyBank.Domain.Models;
using MyBank.Infra.Data.Repository;
using MyBank.Service;
using MyBank.Service.Services;
using System;
using System.Collections.Generic;

namespace MyBank.Application
{
    class Program
    {
        static void Main0(string[] args)
        {
            Console.WriteLine("\nBem-Vindo ao MyBank\n");

            IRepositoryCliente ClienteRepository = new ClienteRepository();
            IServiceCliente ClienteService = new ClienteService(ClienteRepository);

            IRepositoryConta ContaRepository = new ContaRepository();
            IServiceConta ContaService = new ContaService(ContaRepository);

            TestClientes cc = new TestClientes(ClienteRepository, ClienteService);
            cc.ViewAll();

            ContaService.insert(new CreateContaModel(ClienteService.Recover("048.791.300-01"), 100, 100, "12345678"));
            ContaService.insert(new CreateContaModel(ClienteService.Recover("453.200.670-89"), 100, 200, "87654321"));
            List<ReturnContaModel> contaModel = (List<ReturnContaModel>)ContaService.Recover();
            foreach(ReturnContaModel c in contaModel)
            {
                Console.WriteLine("Nome: " + c.Cliente.Nome + " Ag: " + c.Agencia + " Conta: " + c.NumConta);
            }


            ExceptionCatcher.viewAllExceptionsMessagen();         

            Console.WriteLine("Programa finalizado...");
        }

        static void Main(string[] args)
        {
            IRepositoryCliente ClienteRepository = new ClienteRepository();
            IServiceCliente ClienteService = new ClienteService(ClienteRepository);
            //TODO: fazer um repository pra cada tipo de conta.
            IRepositoryConta ContaRepository = new ContaRepository();
            IServiceContaCorrente CorrenteService = new ContaCorrenteService(ContaRepository);
            IServiceContaPoupanca PoupancaServce = new ContaPoupancaService(ContaRepository);

            IDisplayCadastro dc = new CadastroDisplay(ClienteService, CorrenteService, PoupancaServce);

            IDisplayInit display = new InitDisplay(dc);
            display.Init();
        }
    }
}
