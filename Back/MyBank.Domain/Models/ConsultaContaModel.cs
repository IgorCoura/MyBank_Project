namespace MyBank.Domain.Models
{
    public class ConsultaContaModel
    {
        public ConsultaContaModel(string cpf, string agencia, string numConta, double valor)
        {
            Cpf = cpf;
            Agencia = agencia;
            NumConta = numConta;
            Valor = valor;
        }

        public string Cpf { get; set; }
        public string Agencia { get; set; }
        public string NumConta { get; set; }
        public double Valor { get; set; }
    }
}
