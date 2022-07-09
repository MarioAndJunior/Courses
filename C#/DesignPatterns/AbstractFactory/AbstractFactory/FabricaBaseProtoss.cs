using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    public class FabricaBaseProtoss : IFabricaBases
    {
        public FabricaBaseProtoss()
        {
            CriarBase();
        }

        public void CriarBase()
        {
            Console.WriteLine("Base Protoss criada com sucesso!");

            EnergiaBaseProtoss energiaProtoss = new EnergiaBaseProtoss();
            energiaProtoss.Composicao();

            RevestimentoBaseProtoss revestimentoProtoss = new RevestimentoBaseProtoss();
            revestimentoProtoss.Composicao();
        }
    }
}
