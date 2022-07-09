using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    public class Papagaio : IAjuda
    {
        public string Ajudar(Ajuda pedido)
        {
            return "Sou um paapgaio e posso te ajudar a voar!";
        }
    }
}
