using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Domain.Entities
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca(int id, Cliente cliente, int agencia, int numConta, string senha) : base(id, cliente, agencia, numConta, senha)
        {
        }

        public int Rendimento { get; set; }
        public double Saldo { get; set; }
    }
}
