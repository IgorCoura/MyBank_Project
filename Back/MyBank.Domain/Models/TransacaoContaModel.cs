using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Models
{
    public class TransacaoContaModel
    {
        public TransacaoContaModel(string agencia, string numConta, string token, double valor)
        {
            Agencia = agencia;
            NumConta = numConta;
            Token = token;
            Valor = valor;
        }

        public string Agencia { get; set; }
        public string NumConta { get; set; }
        public string Token { get; set; }
        public double Valor { get; set; }
    }

}
