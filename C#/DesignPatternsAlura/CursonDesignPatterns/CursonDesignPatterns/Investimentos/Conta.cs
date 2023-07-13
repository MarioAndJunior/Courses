namespace CursonDesignPatterns.Investimentos
{
    public class Conta
    {
        public Conta(double saldo)
        {
            Saldo = saldo;
        }

        public double Saldo { get; private set; }

        public void Deposita(double valor)
        {
            this.Saldo += valor;
        }
    }
}