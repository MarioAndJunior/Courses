using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsability
{
    public class PersonagemB : Manipulador
    {
        public override void Convoca(int quantidadeDePoder)
        {
            if (quantidadeDePoder >= 10 &&
                quantidadeDePoder < 20)
            {
                Console.WriteLine("{0} convocado para uma força de poder de {1}",
                    this.GetType().Name, quantidadeDePoder);
            }
            else if (sucessor != null)
            {
                sucessor.Convoca(quantidadeDePoder);
            }
        }
    }
}
