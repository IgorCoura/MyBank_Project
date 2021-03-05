using Aurora.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Domain.Models
{
    public class CreateCliente
    {
        public CreateCliente(string nome, string cpf, string dataNascimento)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
        }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string DataNascimento { get; set; }

    }
}
