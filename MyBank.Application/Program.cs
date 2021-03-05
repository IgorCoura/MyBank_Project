using MyBank.Domain.Models;
using MyBank.Service;
using MyBank.Service.Services;
using System;

namespace MyBank.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-Vindo ao MyBank");

            string CPF = "12345678912";

            CreateCliente cliete = new CreateCliente("name", CPF, "20/20/20");

            ClienteService service = new ClienteService();
            service.CriarCliente(cliete);

            Console.WriteLine("Programa finalizado...");
        }
    }
}
