using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    public class FabricaBaseZerg : IFabricaBases
    {
        public FabricaBaseZerg()
        {
            CriarBase();
        }

        public void CriarBase()
        {
            Console.WriteLine("Base Zerg criada com sucesso!");

            EnergiaBaseZerg energiaZerg = new EnergiaBaseZerg();
            energiaZerg.Composicao();

            RevestimentoBaseZerg revestimentoZerg = new RevestimentoBaseZerg();
            revestimentoZerg.Composicao();
        }
    }
}
