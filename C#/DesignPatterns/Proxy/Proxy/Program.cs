using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("### Acessando a Fase do Jogo sem Proxy ###");
            //FaseJogo faseJogo = new FaseJogo();
            //Console.WriteLine(faseJogo.Jogar());
            //Console.WriteLine();
            
            //Console.ReadKey();

            Console.WriteLine("### Acessando a Fase do Jogo com Proxy ###");

            ProxyFase proxyFase = new ProxyFase();
            Console.WriteLine(proxyFase.Jogar());

            Console.WriteLine(proxyFase.InformarPassword("456"));
            Console.WriteLine(proxyFase.InformarPassword("123"));

            Console.WriteLine(proxyFase.Jogar());

            Console.ReadKey();
        }
    }
}
