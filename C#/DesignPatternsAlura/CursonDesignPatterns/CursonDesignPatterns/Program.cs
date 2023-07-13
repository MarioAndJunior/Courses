using CursonDesignPatterns.Investimentos;
using System;

namespace CursonDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //Imposto ISS = new ISS();
            //Imposto ICMS = new ICMS();
            //Imposto ICCC = new ICCC();

            //Orcamento orcamento = new Orcamento(5000.0);

            //CalculadorDeImposto calculadorDeImposto = new CalculadorDeImposto();

            //calculadorDeImposto.RealizaCalculo(orcamento, ISS);
            //calculadorDeImposto.RealizaCalculo(orcamento, ICMS);
            //calculadorDeImposto.RealizaCalculo(orcamento, ICCC);

            //Console.WriteLine("Investimentos");

            //Conta conta = new Conta(1000.0);
            //RealizadorDeInvestimento realizadorDeInvestimento = new RealizadorDeInvestimento();

            //Investimento conservador = new Conservador();
            //Console.WriteLine("Aplicando para o conservador");
            //realizadorDeInvestimento.PagaDividendo(conta, conservador);

            //conta = new Conta(1000.0);

            //Investimento moderado = new Moderado();
            //Console.WriteLine("Aplicando para o moderado");
            //realizadorDeInvestimento.PagaDividendo(conta, moderado);

            //conta = new Conta(1000.0);

            //Investimento arrojado = new Arrojado();
            //Console.WriteLine("Aplicando para o arrojado");
            //realizadorDeInvestimento.PagaDividendo(conta, arrojado);

            CalculadorDeDescontos calculadorDeDescontos = new CalculadorDeDescontos();
            Orcamento orcamento = new Orcamento(500.0);
            orcamento.AdicionaItem(new Item("Caneta", 250.0));
            orcamento.AdicionaItem(new Item("Lapis", 250.0));

            double desconto = calculadorDeDescontos.Calcula(orcamento);
            Console.WriteLine($"Valor do desconto: {desconto}");

            Console.ReadKey();
        }
    }
}
