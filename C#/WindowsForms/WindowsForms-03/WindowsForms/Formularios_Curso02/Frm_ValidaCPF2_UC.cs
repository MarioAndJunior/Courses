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
    public partial class Frm_ValidaCPF2_UC : UserControl
    {
        public Frm_ValidaCPF2_UC()
        {
            InitializeComponent();
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            this.Msk_CPF.Text = string.Empty;
            this.Msk_CPF.Focus();
        }

        private void Btn_Valida_Click(object sender, EventArgs e)
        {
            string conteudo = this.Msk_CPF.Text.Replace(".", "").Replace("-", "");
            int tamanho = conteudo.Length;
            if (tamanho < 11)
            {
                MessageBox.Show("Por favor insira um CPF com 11 caracteres", "Mensagem de validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Frm_Questao db = new Frm_Questao("Frm_ValidaCPF2", "Tem certeza em validar o CPF?");
                db.ShowDialog();
                if (db.DialogResult == DialogResult.Yes)//(MessageBox.Show("Deseja validar o CPF?", "Meensagem de validação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool valido = false;
                    valido = Utils.Valida(Msk_CPF.Text);

                    if (valido == true)
                    {
                        MessageBox.Show("CPF Válido", "Mensagem de validação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("CPF Inválido", "Mensagem de validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


            this.Msk_CPF.Text = string.Empty;
            this.Msk_CPF.Focus();
        }
    }
}
