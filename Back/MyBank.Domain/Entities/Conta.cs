using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Domain.Entities
{
    public class Conta
    {
        public Conta(int id, Cliente cliente, int agencia, int numConta, string senha, double saldo)
        {
            Id = id;
            Cliente = cliente;
            Agencia = agencia;
            NumConta = numConta;
            Senha = senha;
            Saldo = saldo;
        }

        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public int Agencia { get; set; }
        public int NumConta { get; set; }
        public String Senha { get; set; }
        public double Saldo { get; set; }

    }
}
