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
    public partial class Frm_Questao : Form
    {
        public Frm_Questao(string nomeImagem, string mensagem)
        {
            InitializeComponent();

            if(!string.IsNullOrEmpty(nomeImagem) && !string.IsNullOrEmpty(mensagem))
            {
                Image myImage = (Image)global::WindowsForms.Properties.Resources.ResourceManager.GetObject(nomeImagem);
                Pic_Imagem.Image = myImage;
                Lbl_Questao.Text = mensagem;
            }
        }

        private void Btm_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void Btm_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
