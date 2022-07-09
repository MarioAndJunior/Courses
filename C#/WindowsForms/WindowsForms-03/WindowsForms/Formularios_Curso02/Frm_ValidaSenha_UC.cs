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
    public partial class Frm_ValidaSenha_UC : UserControl
    {
        private bool VerSenhaTxt = false;
        public Frm_ValidaSenha_UC()
        {
            InitializeComponent();
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            this.Txt_Senha.Text = string.Empty;
            this.Lbl_Resultado.Text = string.Empty;
        }

        private void Btn_VerSenha_Click(object sender, EventArgs e)
        {
            if (this.VerSenhaTxt == false)
            {
                this.Txt_Senha.PasswordChar = '\0';
                this.VerSenhaTxt = true;
                this.Btn_VerSenha.Text = "Esconder Senha";
            }
            else
            {
                this.Txt_Senha.PasswordChar = '*';
                this.VerSenhaTxt = false;
                this.Btn_VerSenha.Text = "Ver Senha";
            }
        }

        private void Txt_Senha_KeyDown(object sender, KeyEventArgs e)
        {
            ChecaForcaSenha forcaSenha = new ChecaForcaSenha();
            ChecaForcaSenha.ForcaDaSenha forca;
            forca = forcaSenha.GetForcaDaSenha(this.Txt_Senha.Text);
            this.Lbl_Resultado.Text = forca.ToString();

            if (this.Lbl_Resultado.Text == "Inaceitavel" | Lbl_Resultado.Text == "Fraca")
            {
                this.Lbl_Resultado.ForeColor = Color.Red;
            }
            if (this.Lbl_Resultado.Text == "Aceitavel")
            {
                this.Lbl_Resultado.ForeColor = Color.Blue;
            }
            if (this.Lbl_Resultado.Text == "Forte" | Lbl_Resultado.Text == "Segura")
            {
                this.Lbl_Resultado.ForeColor = Color.Green;
            }
        }
    }
}
