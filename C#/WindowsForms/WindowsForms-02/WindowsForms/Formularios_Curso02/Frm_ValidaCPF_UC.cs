using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsBiblioteca;

namespace WindowsForms.UserControls
{
    public partial class Frm_ValidaCPF_UC : UserControl
    {
        public Frm_ValidaCPF_UC()
        {
            InitializeComponent();
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            this.Msk_CPF.Text = string.Empty;
            this.Lbl_Resultado.Text = string.Empty;
            this.Msk_CPF.Focus();
        }

        private void Btm_Valida_Click(object sender, EventArgs e)
        {
            bool valido = false;
            valido = Utils.Valida(Msk_CPF.Text);

            if (valido == true)
            {
                this.Lbl_Resultado.Text = "CPF Válido";
                this.Lbl_Resultado.ForeColor = Color.Green;
            }
            else
            {
                this.Lbl_Resultado.Text = "CPF Inválido";
                this.Lbl_Resultado.ForeColor = Color.Red;
            }
        }
    }
}
