﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Profissao { get; set; }

        public override bool Equals(object obj)
        {
            Cliente outro = obj as Cliente;

            if (outro ==  null)
            {
                return false;
            }
            return this.CPF == outro.CPF;
        }
    }
}
