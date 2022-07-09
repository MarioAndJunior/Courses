using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight
{
    public class Flyweight
    {
        private Dictionary<string, Tartaruga> lista_de_tartarugas = new Dictionary<string, Tartaruga>();

        public Tartaruga GetTartaruga(string cor)
        {
            Tartaruga tartaruga = null;

            if(lista_de_tartarugas.ContainsKey(cor))
            {
                tartaruga = lista_de_tartarugas[cor];
            }
            else
            {
                switch(cor)
                {
                    case "azul":
                        tartaruga = new Azul();
                        break;
                    case "verde":
                        tartaruga = new Verde();
                        break;
                    case "laranja":
                        tartaruga = new Laranja();
                        break;
                    case "vermelha":
                        tartaruga = new Vermelha();
                        break;
                }

                lista_de_tartarugas.Add(cor, tartaruga);
            }

            return tartaruga;
        }
    }
}
