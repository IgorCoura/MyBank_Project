using MyBank.Domain.Interfaces;
using MyBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Application.Display
{
    public class LoginDisplay
    {
        IServiceConta contaService;
        IServiceContaCorrente correnteService;
        IServiceContaPoupanca poupancaService;

        public void Init()
        {
            int agencia;
            int numConta;
            string senha;

            while (true)
            {
                Console.WriteLine("Tela de acessor (Digite '0' para sair a qualquer momento).");
                Console.WriteLine("Agencia: ");
                agencia = Convert.ToInt32(Console.ReadLine());
                if (agencia == 0) { Console.Clear(); return; }
                Console.WriteLine("Conta: ");
                numConta = Convert.ToInt32(Console.ReadLine());
                if (numConta == 0) { Console.Clear(); return; }
                Console.WriteLine("Senha: ");
                senha = Console.ReadLine();
                if (senha == "0") { Console.Clear(); return; }

                ReturnContaModel conta = contaService.Recover(agencia, numConta, senha);

                if (conta == null)
                {
                    Console.Clear();
                    Console.WriteLine("Acesso negado.");
                    continue;
                }


            }

        }

        private void ContaDisplay(ReturnContaModel Rconta, string senha)
        {
            Console.WriteLine("Bem-Vindo " + Rconta.Cliente.Nome + "\n");
            while (true)
            {
                Console.WriteLine("Digite o numero do que deseja");

                var contaCorrente = correnteService.Recover(Rconta.Agencia, Rconta.NumConta);
                var contaPoupanca = poupancaService.Recover(Rconta.Agencia, Rconta.NumConta);

                if (contaCorrente != null)
                {
                    Console.WriteLine("1 - Acessar conta corrente");
                }
                else
                {
                    Console.WriteLine("1 - Criar conta corrente");
                }
                if (contaPoupanca != null)
                {
                    Console.WriteLine("2 - Acessar conta poupanca");
                }
                else
                {
                    Console.WriteLine("2 - Criar conta poupanca");
                }
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        if (contaCorrente != null) { Console.Clear(); ContaCorrenteDislay(); } 
                        else
                        {
                            correnteService.insert(new CreateContaModel(Rconta.Cliente, Rconta.Agencia, Rconta.NumConta, senha));
                            Console.Clear();
                            Console.WriteLine("Conta corrente crianda com sucesso");
                            continue;
                        }
                        break;
                    case "2":
                        if (contaPoupanca != null) { Console.Clear(); ContaPoupancaDisplay(); }
                        else
                        {
                            poupancaService.insert(new CreateContaModel(Rconta.Cliente, Rconta.Agencia, Rconta.NumConta, senha));
                            Console.Clear();
                            Console.WriteLine("Conta poupanca crianda com sucesso");
                            continue;
                        }
                        break;
                }
            }

        }

        private void ContaPoupancaDisplay()
        {
            throw new NotImplementedException();
        }

        private void ContaCorrenteDislay()
        {
            throw new NotImplementedException();
        }
    }
}
