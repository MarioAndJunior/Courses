using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    class CriadorDeForcasEspeciais : CriadorDeSoldado
    {
        public CriadorDeForcasEspeciais()
        {
            _soldado = new SoldadoDeForcasEspeciais();
        }

        public override void Arma()
        {
            _soldado.EscolherArma("Fuzil");
        }

        public override void Foco()
        {
            _soldado.DefinirFoco("Combate em solo");
        }

        public override void Transporte()
        {
            _soldado.EscolherTransporte("Carro de operações especiais");
        }
    }
}
