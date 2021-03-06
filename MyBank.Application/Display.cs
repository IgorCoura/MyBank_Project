using MyBank.Domain;
using MyBank.Domain.Entities;
using MyBank.Domain.Interfaces;
using MyBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Application
{
    public class Display
    {
        IServiceCliente ClienteService;

        public Display(IServiceCliente clienteService)
        {
            ClienteService = clienteService;
        }


        public void Init()
        {
            bool restart = true;
            while (restart)
            {
                Console.Clear();
                Console.WriteLine("1 - Acessar conta bancaria");
                Console.WriteLine("2 - Criar uma nova conta");
                Console.WriteLine("0 - Encerra programa");

                if (!Int32.TryParse(Console.ReadLine(), out int opcao))
                {
                    Console.WriteLine("Erro. Por favor digite o numero da opção desejada.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("1");
                        break;
                    case 2:
                        if (Cadastro()) continue;
                        break;
                }
                restart = false;
            }

        }

        public bool Cadastro()
        {
            bool restart = true;
            while (restart)
            {
                Console.Clear();
                Console.WriteLine("1 - Já tenho cadastro");
                Console.WriteLine("2 - Fazer cadastro");
                Console.WriteLine("0 - Voltar");

                if (!Int32.TryParse(Console.ReadLine(), out int opcao))
                {
                    Console.WriteLine("Erro. Por favor digite o numero da opção desejada.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        NovaConta();
                        continue;
                    case 2:
                        Cliente c = NovoCliete();
                        if(c != null)
                        {
                            NovaConta(c);
                        }
                        continue;
                }
                restart = false;
            }
            return true;
        }

        public Cliente NovoCliete()
        {           
            Console.Clear();
            do
            {
                string nome;
                string cpf;
                string DataNascimento;

                Console.WriteLine("Cadastro de novo clientes (Digite '0' para sair a qualquer momento).");
                Console.WriteLine("Digite seu nome:");
                nome = Console.ReadLine();
                if (nome == "0") return null;
                Console.WriteLine("Digite seu CPF:");
                cpf = Console.ReadLine();
                if (cpf == "0") return null;
                Console.WriteLine("Digite sua data de Nascimento:");
                DataNascimento = Console.ReadLine();
                if (DataNascimento == "0") return null;

                ClienteService.Insert(new CreateClienteModel(nome, cpf, DataNascimento));

                ExceptionCatcher.viewAllExceptionsMessagen();
                if (ExceptionCatcher.countException() > 0) continue;

                return ClienteService.Recover(cpf);

            } while (true);
                      
        }

        public void NovaConta(Cliente cliente = null)
        {

            Console.WriteLine("Cadastro de nova contas (Digite '0' para sair a qualquer momento).");
            if (cliente == null)
            {
                Console.WriteLine("Digite o seu CPF: ");
                var cpf = Console.ReadLine();
                cliente = ClienteService.Recover(cpf);        
            }

        }
    }
}

