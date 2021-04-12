using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Models
{
    public class DeleteContaModel
    {
        public DeleteContaModel(string agencia, string numConta, string token)
        {
            this.Agencia = agencia;
            this.NumConta = numConta;
            this.Token = token;
        }

        public string Agencia { get; set; }
        public string NumConta { get; set; }
        public string Token { get; set; }
    }

}
