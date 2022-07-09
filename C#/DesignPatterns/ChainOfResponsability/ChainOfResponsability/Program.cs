using System;

namespace ChainOfResponsability
{
    class Program
    {
        static void Main(string[] args)
        {
            Manipulador personagemA = new PersonagemA();
            Manipulador personagemB = new PersonagemB();
            Manipulador personagemC = new PersonagemC();

            personagemA.defineSucessor(personagemB);
            personagemB.defineSucessor(personagemC);

            int[] requisicoes = { 5, 8, 15, 20, 18, 3, 27, 20 };

            foreach( int requisicao in requisicoes)
            {
                personagemA.Convoca(requisicao);
            }

            Console.ReadKey();
        }
    }
}
