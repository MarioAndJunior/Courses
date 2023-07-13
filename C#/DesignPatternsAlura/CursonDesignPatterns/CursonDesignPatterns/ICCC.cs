namespace CursonDesignPatterns
{
    public class ICCC : Imposto
    {
        public double Calcula(Orcamento orcamento)
        {
            double imposto = 0.0;

            if (orcamento.Valor < 1000.0)
            {
                imposto = orcamento.Valor * 0.05;
            }
            else if (orcamento.Valor >= 1000.0 && orcamento.Valor <= 3000.0)
            {
                imposto = orcamento.Valor * 0.07;
            }
            else
            {
                imposto = (orcamento.Valor * 0.08) + 30.0;
            }

            return imposto;
        }
    }
}
