using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Frm_Mascara : Form
    {
        public Frm_Mascara()
        {
            InitializeComponent();
        }

        private void Btn_Hora_Click(object sender, EventArgs e)
        {
            this.Msk_TextBox.UseSystemPasswordChar = false;
            this.Msk_TextBox.Text = string.Empty;
            this.Lbl_Conteudo.Text = string.Empty;
            this.Msk_TextBox.Mask = "00:00";
            this.Lbl_MascaraAtiva.Text = this.Msk_TextBox.Mask;
            this.Msk_TextBox.Focus();
        }

        private void Btn_VerConteudo_Click(object sender, EventArgs e)
        {
            this.Lbl_Conteudo.Text = this.Msk_TextBox.Text;
        }

        private void Btn_CEP_Click(object sender, EventArgs e)
        {
            this.Msk_TextBox.UseSystemPasswordChar = false;
            this.Msk_TextBox.Text = string.Empty;
            this.Lbl_Conteudo.Text = string.Empty;
            this.Msk_TextBox.Mask = "00000-000";
            this.Lbl_MascaraAtiva.Text = this.Msk_TextBox.Mask;
            this.Msk_TextBox.Focus();
        }

        private void Btn_Moeda_Click(object sender, EventArgs e)
        {
            this.Msk_TextBox.UseSystemPasswordChar = false;
            this.Msk_TextBox.Text = string.Empty;
            this.Lbl_Conteudo.Text = string.Empty;
            this.Msk_TextBox.Mask = "$ 000,000,000.00";
            this.Lbl_MascaraAtiva.Text = this.Msk_TextBox.Mask;
            this.Msk_TextBox.Focus();
        }

        private void Btn_Data_Click(object sender, EventArgs e)
        {
            this.Msk_TextBox.UseSystemPasswordChar = false;
            this.Msk_TextBox.Text = string.Empty;
            this.Lbl_Conteudo.Text = string.Empty;
            this.Msk_TextBox.Mask = "00/00/0000";
            this.Lbl_MascaraAtiva.Text = this.Msk_TextBox.Mask;
            this.Msk_TextBox.Focus();
        }

        private void Btn_Telefone_Click(object sender, EventArgs e)
        {
            this.Msk_TextBox.UseSystemPasswordChar = false;
            this.Msk_TextBox.Text = string.Empty;
            this.Lbl_Conteudo.Text = string.Empty;
            this.Msk_TextBox.Mask = "(00) 0000-0000";
            this.Lbl_MascaraAtiva.Text = this.Msk_TextBox.Mask;
            this.Msk_TextBox.Focus();
        }

        private void Btn_Senha_Click(object sender, EventArgs e)
        {
            this.Msk_TextBox.UseSystemPasswordChar = true;
            this.Lbl_Conteudo.Text = string.Empty;
            this.Msk_TextBox.Mask = "000000";
            this.Lbl_MascaraAtiva.Text = this.Msk_TextBox.Mask;
            this.Msk_TextBox.Focus();
        }
    }
}
