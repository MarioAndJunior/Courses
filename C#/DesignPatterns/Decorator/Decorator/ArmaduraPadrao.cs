using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public class ArmaduraPadrao : MoldeArmadura
    {
        string _descricao = "Proteção simples, ";

        public override string Descricao
        {
            get{ return _descricao;}
        }
    }
}
