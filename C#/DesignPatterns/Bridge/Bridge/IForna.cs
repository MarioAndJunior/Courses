using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge
{
    public interface IForna
    {
        string Descer();
        ICor ICor { get; set; }
    }
}
