using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Domain.Entities
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente(int id, Cliente cliente, int agencia, int numConta, string senha, double saldo) : base(id, cliente, agencia, numConta, senha, saldo)
        {
        }



        private int ChequeEspecial = 1500;

        public int ChequeEspecial1 { get => ChequeEspecial; set => ChequeEspecial = value; }
    }
}
