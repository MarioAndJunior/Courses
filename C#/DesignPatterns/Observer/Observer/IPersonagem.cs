using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public interface IPersonagem
    {
        void RegistrarObservador(IObservador observador);
        void NotificarPersonagens();
    }
}
