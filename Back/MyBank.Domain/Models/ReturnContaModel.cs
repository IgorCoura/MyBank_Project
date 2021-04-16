namespace MyBank.Domain.Models
{
    public class ReturnContaModel
    {
        public ReturnContaModel(int id, string agencia, string numConta, double saldo)
        {
            Id = id;
            Agencia = agencia;
            NumConta = numConta;
            Saldo = saldo;
        }

        public int Id { get; set; }
        public string Agencia { get; set; }
        public string NumConta { get; set; }
        public double Saldo { get; set; }
    }
}
