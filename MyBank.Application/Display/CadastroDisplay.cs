using MyBank.Domain;
using MyBank.Domain.Entities;
using MyBank.Domain.Interfaces;
using MyBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Application.Display
{
    public class CadastroDisplay: IDisplayCadastro
    {
        readonly IServiceCliente ClienteService;
        readonly IServiceContaCorrente CorrenteService;
        readonly IServiceContaPoupanca PoupancaService;

        public CadastroDisplay(IServiceCliente clienteService, IServiceContaCorrente correnteService, IServiceContaPoupanca poupancaService)
        {
            CorrenteService = correnteService;
            PoupancaService = poupancaService;
            ClienteService = clienteService;
        }

        public Cliente NovoCliete()
        {

            Console.Clear();
            do
            {
                string nome;
                string cpf;
                string DataNascimento;

                Console.WriteLine("Cadastro de novos clientes (Digite '0' para sair a qualquer momento).");
                Console.WriteLine("Digite seu nome:");
                nome = Console.ReadLine();
                if (nome == "0") { Console.Clear(); return null; }
                Console.WriteLine("Digite seu CPF:");
                cpf = Console.ReadLine();
                if (cpf == "0") { Console.Clear(); return null; }
                Console.WriteLine("Digite sua data de Nascimento:");
                DataNascimento = Console.ReadLine();
                if (DataNascimento == "0") { Console.Clear(); return null; }
                Console.Clear();

                ClienteService.Insert(new CreateClienteModel(nome, cpf, DataNascimento));

                var cc = ClienteService.Recover(cpf);

                ExceptionCatcher.viewAllExceptionsMessagen();
                if (ExceptionCatcher.countException() > 0) continue;

                return cc;

            } while (true);

        }

        public bool NovaConta(Cliente cliente = null)
        {
            int agencia;
            int numConta;
            string senha;

            if (cliente == null)
            {
                Console.WriteLine("Digite o seu CPF: ");
                var cpf = Console.ReadLine();
                cliente = ClienteService.Recover(cpf);

                if (cliente == null)
                {
                    Console.Clear();
                    ExceptionCatcher.clean();
                    Console.WriteLine("CPF não encontrado.\n");
                    return false;
                }

            }

            while (true)
            {
                Console.WriteLine("Bem-vindo " + cliente.Nome + " ao Cadastro de nova contas (Digite '0' para sair a qualquer momento).\n");

                Console.WriteLine("Digite o numero do tipo de conta de gostaria de abrir.");
                Console.WriteLine("1 - Conta corrente.");
                Console.WriteLine("2 - Conta poupanca.");
                Console.WriteLine("0 - Voltar.");

                if (!Int32.TryParse(Console.ReadLine(), out int opcao))
                {
                    Console.WriteLine("Erro. Por favor digite o numero da opção desejada.");
                    continue;
                }
                if (opcao == 0) { Console.Clear(); return false; }

                //TODO: Impedir o cadastro em agencias inexistente no sistema
                Console.WriteLine("Informe sua agencia: ");
                agencia = Convert.ToInt32(Console.ReadLine());
                if (agencia == 0) { Console.Clear(); return false; }
                //TODO: Mudar pra um geracao automatico de conta com digito
                Console.WriteLine("Informe sua conta: ");
                numConta = Convert.ToInt32(Console.ReadLine());
                if (numConta == 0) { Console.Clear(); return false; }
                //TODO: Se possivel deixar senha invisivel na digitacao
                Console.WriteLine("Digite sua senha: ");
                senha = Console.ReadLine();
                if (senha == "0") { Console.Clear(); return false; }

                switch (opcao)
                {
                    case 1:
                        CorrenteService.insert(new CreateContaModel(cliente, agencia, numConta, senha));
                        break;
                    case 2:
                        PoupancaService.insert(new CreateContaModel(cliente, agencia, numConta, senha));
                        break;
                }
                Console.Clear();
                Console.WriteLine("Nova conta Criada com exito.");
                //TODO: print nas informacoes depois de criar conta
                return true;
            }

        }
    }
}
