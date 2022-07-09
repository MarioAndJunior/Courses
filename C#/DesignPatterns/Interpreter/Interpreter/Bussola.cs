using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter
{
    public class Bussola : IFerramenta
    {
        public void Interpretar(Contexto contexto)
        {
            contexto.Conteudo += string.Format(" {0} ", " Bussola ");
        }
    }
}
