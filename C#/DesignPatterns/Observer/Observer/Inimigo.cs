using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public class Inimigo : IObservador
    {
        private Cody personagemObservado;
        private string nome = "";
        public void Avisar(IPersonagem personagem)
        {
            if(personagem == personagemObservado)
            {
                Console.WriteLine("o Cody foi acertado com um golpe, agora sua vida de jogo é de " + personagemObservado.GetVida() + " inimigo: " + this.nome);
            }
        }

        public Inimigo(Cody cody, string nome)
        {
            personagemObservado = cody;
            personagemObservado.RegistrarObservador(this);
            this.nome = nome;
        }
    }
}
