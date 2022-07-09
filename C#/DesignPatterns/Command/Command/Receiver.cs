using System;

namespace Command
{
    internal class Receiver
    {
        internal void PrimeiroPedido(string a)
        {
            Console.WriteLine("Comando recebido " + a);
        }

        internal void SegundoPedido(string b)
        {
            Console.WriteLine("Comando recebido " + b);
        }
    }
}