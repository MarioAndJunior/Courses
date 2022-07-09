using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter
{
    public class ArcoFlecha : IArmamento
    {
        public void Interpretar(Contexto contexto)
        {
            contexto.Conteudo += string.Format(" {0} ", " Arco e Flecha");
        }
    }
}
