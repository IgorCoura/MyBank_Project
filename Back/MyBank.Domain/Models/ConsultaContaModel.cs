using MyBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Models
{
    public class ConsultaContaModel
    {
        public ConsultaContaModel(string cpf, int agencia, int numConta, double valor)
        {
            Cpf = cpf;
            Agencia = agencia;
            NumConta = numConta;
            Valor = valor;
        }

        public string Cpf { get; set; }
        public int Agencia { get; set; }
        public int NumConta { get; set; }
        public double Valor { get; set; }
    }
}
