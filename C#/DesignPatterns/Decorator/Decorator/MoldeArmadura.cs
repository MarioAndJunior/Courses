using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public abstract class MoldeArmadura
    {
        private string _descricao = "Armadura do personagem abstrato";

        public virtual string Descricao
        {
            get { return _descricao; }
        }
    }
}
