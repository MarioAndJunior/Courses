using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter
{
    public class Personagem : IAcao
    {
        public void Andar(string jogador)
        {
            Console.WriteLine(jogador + " ANDOU PARA A FRENTE!");
        }

        public void Atirar()
        {
            Console.WriteLine("Atirou no jogo");
        }
    }
}
