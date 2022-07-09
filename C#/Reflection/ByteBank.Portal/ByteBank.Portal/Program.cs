using ByteBank.Portal.Infraestrutura;
using System;

namespace ByteBank.Portal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] prefixos = { "http://localhost:5341/" };
            WebApplication webApplication = new WebApplication(prefixos);
            webApplication.Iniciar();
            Console.WriteLine("Hello World!");
        }
    }
}
