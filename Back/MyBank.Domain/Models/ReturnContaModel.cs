namespace MyBank.Domain.Models
{
    public class ReturnContaModel
    {
        public ReturnContaModel(int id, int agencia, int numConta, double saldo)
        {
            Id = id;
            Agencia = agencia;
            NumConta = numConta;
            Saldo = saldo;
        }

        public int Id { get; set; }
        public int Agencia { get; set; }
        public int NumConta { get; set; }
        public double Saldo { get; set; }
    }
}
