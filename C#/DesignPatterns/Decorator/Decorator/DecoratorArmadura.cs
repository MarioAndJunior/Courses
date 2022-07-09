using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public class DecoratorArmadura : MoldeArmadura
    {
        string _descricao = "Decorador Abstrato da Armadura do Personagem";

        public override string Descricao
        {
            get { return _descricao; }
        }
    }
}
