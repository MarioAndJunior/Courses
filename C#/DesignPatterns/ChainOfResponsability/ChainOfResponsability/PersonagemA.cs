using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsability
{
    public class PersonagemA : Manipulador
    {
        public override void Convoca(int quantidadeDePoder)
        {
            if (quantidadeDePoder >= 0 &&
                quantidadeDePoder < 10)
            {
                Console.WriteLine("{0} convocado para uma força de poder de {1}", 
                    this.GetType().Name, quantidadeDePoder);
            }
            else if(sucessor != null)
            {
                sucessor.Convoca(quantidadeDePoder);
            }
        }
    }
}
