using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public class Diretor : FuncionarioAutenticavel
    {
        private const double SalarioBase = 5000.0;
        public Diretor(string cpf) : base(SalarioBase, cpf)
        {
        }

        public override double GetBonificacao()
        {
            return Salario * 0.5;
        }

        public override void AumentaSalario()
        {
            Salario *= 1.15;
        }
    }
}
