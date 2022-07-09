using System;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Cody cody = new Cody();

            Inimigo inimigo1 = new Inimigo(cody, "Tenente Booth");
            Inimigo inimigo2 = new Inimigo(cody, "Zélão esmaga crânio");
            Inimigo inimigo3 = new Inimigo(cody, "João quebra-queixo");

            while(cody.GetVida() > 0)
            {
                Console.WriteLine("Acertar o Cody com um golpe (s ou n) ???");

                if(Console.ReadKey().KeyChar == 's')
                {
                    cody.Golpe_Acertado(true);
                }
                else
                {
                    Console.WriteLine("Você não acertou o Cody!");
                }
            }

            Console.WriteLine("Cody derrotado!");
        }
    }
}
