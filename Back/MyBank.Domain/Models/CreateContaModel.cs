using System;

namespace MyBank.Domain.Models
{
    public class CreateContaModel
    {
        public CreateContaModel(int agencia, int numConta, string token)
        {
            Agencia = agencia;
            NumConta = numConta;
            Token = token;
        }
        public int Agencia { get; set; }
        public int NumConta { get; set; }
        public string Token { get; set; }
    }
}
