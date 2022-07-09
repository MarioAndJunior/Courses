using ByteBank.Funcionarios;
using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculaBonificacao();
            AutenticaInterno();
            Console.ReadLine();
        }

        public static void AutenticaInterno()
        {
            SistemaInterno sistemaInterno = new SistemaInterno();

            GerenteDeConta maria = new GerenteDeConta("222.555.333-44");
            maria.Nome = "Maria Alice";
            maria.AumentaSalario();
            maria.Senha = "123";
            sistemaInterno.Logar(maria, "123");

            Diretor roberta = new Diretor("212.434.987-45");
            roberta.Nome = "Roberta Arcoverde";
            roberta.AumentaSalario();
            roberta.Senha = "abc";
            sistemaInterno.Logar(roberta, "abc");

            ParceiroComercial parceiroComercial = new ParceiroComercial();
            parceiroComercial.Senha = "123456";
            sistemaInterno.Logar(parceiroComercial, "123456");

        }
        public static void CalculaBonificacao()
        {
            GerenciadorBonificacao gerenciador = new GerenciadorBonificacao();

            Auxiliar carlos = new Auxiliar("111.222.333-44");
            carlos.Nome = "Carlos Silva";
            carlos.AumentaSalario();
            gerenciador.Registra(carlos);

            Designer mario = new Designer("222.222.333-44");
            mario.Nome = "Mario Silva";
            mario.AumentaSalario();
            gerenciador.Registra(mario);

            Desenvolvedor joao = new Desenvolvedor("222.555.666-44");
            joao.Nome = "Joao Andrade";
            joao.AumentaSalario();
            gerenciador.Registra(joao);

            GerenteDeConta maria = new GerenteDeConta("222.555.333-44");
            maria.Nome = "Maria Alice";
            maria.AumentaSalario();
            gerenciador.Registra(maria);

            Diretor roberta = new Diretor("212.434.987-45");
            roberta.Nome = "Roberta Arcoverde";
            roberta.AumentaSalario();
            gerenciador.Registra(roberta);

            Console.WriteLine("Total de bonificações " + gerenciador.GetTotalBonificacao());
            Console.WriteLine("Total de funcionarios " + Funcionario.TotalDeFuncionarios);
        }
    }
}