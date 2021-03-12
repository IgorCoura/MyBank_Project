﻿using Aurora.Domain.ValueTypes;
using MyBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Domain.Entities
{
    public class Cliente
    {
        public Cliente(int id, string nome, CPF cpf, string dataNascimento)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public CPF CPF { get; set; }
        public string DataNascimento { get; set; }

        
    }
}
