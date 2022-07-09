using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter
{
    public class Mochila : IExpressao
    {

        private readonly IFerramenta ferramenta_principal;
        private readonly IFerramenta ferramenta_secundaria;
        private readonly IArmamento armamento;

        public Mochila(IFerramenta ferramenta_principal, 
                        IFerramenta ferramenta_secundaria,
                        IArmamento armamento)
        {
            this.ferramenta_principal = ferramenta_principal;
            this.ferramenta_secundaria = ferramenta_secundaria;
            this.armamento = armamento;
        }
        public void Interpretar(Contexto contexto)
        {
            contexto.Conteudo += "Abrindo mochila... \n";

            armamento.Interpretar(contexto);
            contexto.Conteudo += "- 1a Ferramenta";
            ferramenta_principal.Interpretar(contexto);
            contexto.Conteudo += "- 2a Ferramenta";
            ferramenta_secundaria.Interpretar(contexto);

            contexto.Conteudo += "\n... Fechando mochila";

            Console.WriteLine(contexto.Conteudo);
        }
    }
}
