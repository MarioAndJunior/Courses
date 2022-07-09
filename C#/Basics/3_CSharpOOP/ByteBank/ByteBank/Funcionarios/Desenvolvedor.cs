using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public class Desenvolvedor : Funcionario
    {
        private const double SalarioBase = 3000.0;
        public Desenvolvedor(string cpf) : base(SalarioBase, cpf)
        {
        }

        public override void AumentaSalario()
        {
            Salario *= 0.25;
        }

        public override double GetBonificacao()
        {
            return Salario * 0.25;
        }
    }
}
