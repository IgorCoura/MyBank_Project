using MyBank.Service.Services;
using System;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaService conta = new ContaService();
            var a = conta.geradorNumeroConta();
            Console.WriteLine(a);
        }
    }
}
