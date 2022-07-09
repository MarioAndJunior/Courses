using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cliente gabriela = new Cliente();

            //gabriela.nome = "Gabriela";
            //gabriela.profissao = "Desenvolvedora C#";
            //gabriela.cpf = "444.333.222-11";

            ContaCorrente contaDaGabriela = new ContaCorrente();

            //contaDaGabriela.cliente = new Cliente();

            contaDaGabriela.cliente.nome = "Gabriela";
            contaDaGabriela.cliente.profissao = "Desenvolvedora C#";
            contaDaGabriela.cliente.cpf = "444.333.222-11";

            contaDaGabriela.saldo = 500;
            contaDaGabriela.numero = 556688;
            contaDaGabriela.agencia = 1212;

            Console.WriteLine("Saldo da conta: " + contaDaGabriela.saldo);
            Console.WriteLine(contaDaGabriela.cliente.GetHashCode());

            Console.ReadLine();
        }
    }
}
