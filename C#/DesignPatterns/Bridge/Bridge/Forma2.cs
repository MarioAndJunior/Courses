using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge
{
    public class Forma2 : IForna
    {
        public ICor ICor { get;  set; }

        public string Descer()
        {
            return "U - " + ICor.Cor();
        }
    }
}
