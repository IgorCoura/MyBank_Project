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
    public class InitDisplay: IDisplayInit
    {
        readonly IDisplayCadastro cadastroDisplay;

        public InitDisplay(IDisplayCadastro cadastroDisplay)
        {          
            this.cadastroDisplay = cadastroDisplay;
        }


        public void Init()
        {
            bool restart = true;
            while (restart)
            {
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
                        Console.Clear();
                        AcessarConta();
                        break;
                    case 2:
                        Console.Clear();
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
                        Console.Clear();
                        if (cadastroDisplay.NovaConta()) return true;
                        continue;
                    case 2:
                        Console.Clear();
                        Cliente c = cadastroDisplay.NovoCliete();
                        if (c != null)
                        {
                            if (cadastroDisplay.NovaConta(c)) return true;
                        }
                        continue;
                }
                restart = false;
            }
            Console.Clear();
            return true;
        }

        public bool AcessarConta()
        {
            return true;
        }
    }
}






