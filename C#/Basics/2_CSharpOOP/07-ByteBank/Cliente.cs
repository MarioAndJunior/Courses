using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ByteBank
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Profissao { get; set; }
        public string _cpf;

        public string CPF 
        { 
            get
            {
                return this._cpf;
            }
            set
            {
                this._cpf = value;
            }
        }
    }
}
