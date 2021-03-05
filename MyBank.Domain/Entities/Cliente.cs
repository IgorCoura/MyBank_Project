using Aurora.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Domain.Entities
{
    public class Cliente
    {
        public Cliente(int id, string nome, CPF cpf, string dataNascimento, double credito)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            Credito = credito;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public CPF CPF { get; set; }
        public string DataNascimento { get; set; }
        public double Credito { get; set; }
    }
}
