using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    public interface IJogo
    {
        void Visitante(IVisitor visitante);
    }
}
