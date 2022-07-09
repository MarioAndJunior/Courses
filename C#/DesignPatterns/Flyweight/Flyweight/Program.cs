using System;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            Flyweight flyweight = new Flyweight();
            string cor = string.Empty;

            Tartaruga tartaruga;

            while(true)
            {
                Console.WriteLine();

                Console.WriteLine("Qual tartaruga enviar para a tela: ");

                cor = Console.ReadLine();

                tartaruga = flyweight.GetTartaruga(cor);
                if(tartaruga != null)
                {
                    tartaruga.Mostra(cor);
                }
                else if(cor == "sair")
                {
                    break;
                }

                Console.WriteLine();
                Console.WriteLine("------------------------------------");
            }
        }
    }
}
