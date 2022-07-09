using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    class FactoryMethod
    {
        public IPersonagem Escolher_Personagem(String nomePersonagem)
        {
            switch(nomePersonagem)
            {
                case "Liu Kang":
                    return new LiuKang();
                case "Scorpion":
                    return new Scorpion();
                case "Sub Zero":
                    return new SubZero();
                default:
                    return null;
            }
        }
    }
}
