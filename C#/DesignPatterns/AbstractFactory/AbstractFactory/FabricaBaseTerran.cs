using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    public class FabricaBaseTerran : IFabricaBases
    {
        public FabricaBaseTerran()
        {
            CriarBase();
        }
        public void CriarBase()
        {
            Console.WriteLine("Base Terran criada com sucesso!");

            RevestimentoBaseTerran revestimentoTerran = new RevestimentoBaseTerran();
            revestimentoTerran.Composicao();

            EnergiaBaseTerran energiaTerran = new EnergiaBaseTerran();
            energiaTerran.Composicao();
        }
    }
}
