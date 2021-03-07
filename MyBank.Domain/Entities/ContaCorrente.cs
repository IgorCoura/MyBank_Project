using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Domain.Entities
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente(int id, Cliente cliente, int agencia, int numConta, string senha) : base(id, cliente, agencia, numConta, senha)
        {
        }

        public int ChequeEspecial { get; set; }
        public double Saldo { get; set; }
    }
}
