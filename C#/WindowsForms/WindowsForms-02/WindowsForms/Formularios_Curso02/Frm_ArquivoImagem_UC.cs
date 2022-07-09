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
    public partial class Frm_ArquivoImagem_UC : UserControl
    {
        public Frm_ArquivoImagem_UC(string nomeArquivoImagem)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(nomeArquivoImagem))
            {
                this.Lbl_ArquivoImagem.Text = nomeArquivoImagem;
                this.Pic_ArquivoImagem.Image = Image.FromFile(nomeArquivoImagem);
            }
        }

        private void Btm_Cor_Click(object sender, EventArgs e)
        {
            ColorDialog db = new ColorDialog();
            if (db.ShowDialog() == DialogResult.OK)
            {
                this.Lbl_ArquivoImagem.ForeColor = db.Color;
            }
        }

        private void Btn_Fonte_Click(object sender, EventArgs e)
        {
            FontDialog db = new FontDialog();
            if (db.ShowDialog() == DialogResult.OK)
            {
                this.Lbl_ArquivoImagem.Font = db.Font;
            }
        }
    }
}
