using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Domain.Entities
{
    class ContaCorrente : Conta
    {
        public ContaCorrente(int id, Cliente cliente, int agencia, int numConta, int senha, double saldo) : base(id, cliente, agencia, numConta, senha)
        {
        }

        public int ChequeEspecial { get; set; }
        public double Saldo { get; set; }
    }
}
