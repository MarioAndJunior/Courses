using System;
using System.Collections.Generic;
using System.Text;

namespace Command
{
    public class Controle
    {
        private ICommand comandoSimples;
        private ICommand comandoComplexo;

        public void EnviarComandoSimples(ICommand comando)
        {
            this.comandoSimples = comando;
        }

        public void EnviarComandoComplexo(ICommand comando)
        {
            this.comandoComplexo = comando;
        }
        public void Fazer()
        {
            Console.WriteLine("Ok, vou executar para você!");
            if(this.comandoSimples is ICommand)
            {
                this.comandoSimples.Executar();
            }

            if(this.comandoComplexo is ICommand)
            {
                this.comandoComplexo.Executar();
            }
        }
    }
}
