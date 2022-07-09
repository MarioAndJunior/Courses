using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            FactoryMethod factory = new FactoryMethod();

            Console.WriteLine("Liu Kang | Sub Zero | Scorpion");
            Console.WriteLine();

            Console.WriteLine("Por favor selecione seu personagem");
            string selecionado = Console.ReadLine();
            IPersonagem personagem = factory.Escolher_Personagem(selecionado);

            Console.Write("Você jogará com: ");
            
            if(personagem != null)
            {
                personagem.Escolhido();
            }
            else
            {
                Console.WriteLine("Personagem errado!!!");
            }
        }
    }
}
