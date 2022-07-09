using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public class Cody : IPersonagem
    {
        private List<IObservador> inimigos = new List<IObservador>();
        private int vida = 100;

        public void NotificarPersonagens()
        {
            foreach(IObservador observador in inimigos)
            {
                observador.Avisar(this);
            }
        }

        public void RegistrarObservador(IObservador observador)
        {
            this.inimigos.Add(observador);
        }

        public void Golpe_Acertado(bool golpe)
        {
            if(golpe)
            {
                this.vida -= 10;
                NotificarPersonagens();
            }
        }

        public int GetVida()
        {
            return this.vida;
        }
    }
}
