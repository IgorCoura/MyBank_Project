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
            this.Agencia = agencia;
            this.NumConta = numConta;
            this.Token = token;
            Valor = valor;
        }

        public string Agencia { get; }
        public string NumConta { get;  }
        public string Token { get; }
        public double Valor { get; set; }
    }

}
