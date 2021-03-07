using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Domain.Entities
{
    public class Conta
    {
        public Conta(int id, Cliente cliente, int agencia, int numConta, string senha)
        {
            Id = id;
            Cliente = cliente;
            Agencia = agencia;
            NumConta = numConta;
            Senha = senha;
        }

        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public int Agencia { get; set; }
        public int NumConta { get; set; }
        public String Senha { get; set; }

    }
}
