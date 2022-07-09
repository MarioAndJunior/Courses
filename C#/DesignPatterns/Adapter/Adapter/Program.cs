using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Personagem mario = new Personagem();
            Aviao aviao_de_batalha = new Aviao();

            IAcao adaptador = new Adapter(aviao_de_batalha);

            Console.WriteLine("--- CAMINHANDO ---");
            mario.Andar("Mario");
            mario.Atirar();

            Console.WriteLine();

            Console.WriteLine("--- PEGOU UM AVIÃO NO JOGO ---");
            adaptador.Andar("Mario");
            adaptador.Atirar();

            Console.ReadKey();
        }
    }
}
