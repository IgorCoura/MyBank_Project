﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Domain.Entities
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca(int id, Cliente cliente, int agencia, int numConta, string senha, double saldo) : base(id, cliente, agencia, numConta, senha, saldo)
        {
        }

        public int Rendimento { get; set; }

    }
}
