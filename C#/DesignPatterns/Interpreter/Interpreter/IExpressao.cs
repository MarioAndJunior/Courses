using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter
{
    public interface IExpressao
    {
        void Interpretar(Contexto contexto);
    }
}
