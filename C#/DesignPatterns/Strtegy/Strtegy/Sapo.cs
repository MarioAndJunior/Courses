using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    public class Sapo : IAjuda
    {
        public string Ajudar(Ajuda pedido)
        {
            return "SOu um sapo e posso te ajudar a pular bem alto";
        }
    }
}
