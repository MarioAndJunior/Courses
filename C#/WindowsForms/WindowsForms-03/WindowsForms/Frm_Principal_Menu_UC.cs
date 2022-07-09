using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.UserControls;
using WindowsFormsBiblioteca;

namespace WindowsForms
{
    public partial class Frm_Principal_Menu_UC : Form
    {
        private int ControleHelloWorld;
        private int ControleDemonstracaoKey;
        private int ControleMascara;
        private int ControleValidaCPF;
        private int ControleValidaCPF2;
        private int ControleChecaForcaSenha;
        private int ControleArquivoImagem;

        public Frm_Principal_Menu_UC()
        {
            InitializeComponent();
            this.novoToolStripMenuItem.Enabled = false;
            this.apagarAbaToolStripMenuItem.Enabled = false;
            this.abrirImagemToolStripMenuItem.Enabled = false;
            this.desconectarToolStripMenuItem.Enabled = false;
        }
        private void demonstraçãoKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ControleDemonstracaoKey++;
            Frm_DemonstracaoKey_UC U = new Frm_DemonstracaoKey_UC();
            U.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = "Demonstração Key " + ControleHelloWorld;
            TB.Text = "Demonstração Key " + ControleHelloWorld;
            TB.ImageIndex = 0;
            TB.Controls.Add(U);

            Tbc_Aplicacoes.TabPages.Add(TB);
        }

        private void helloWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ControleHelloWorld++;
            Frm_HelloWorld_UC U = new Frm_HelloWorld_UC();
            U.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = $"Hello World {this.ControleHelloWorld}";
            TB.Text = $"Hello World {this.ControleHelloWorld}";
            TB.ImageIndex = 1;
            TB.Controls.Add(U);

            Tbc_Aplicacoes.TabPages.Add(TB);
        }

        private void máscaraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ControleMascara++;
            Frm_Mascara_UC U = new Frm_Mascara_UC();
            U.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = "Máscara " + ControleMascara;
            TB.Text = "Máscara " + ControleMascara;
            TB.ImageIndex = 2;
            TB.Controls.Add(U);

            Tbc_Aplicacoes.TabPages.Add(TB);
        }

        private void validaCPFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ControleValidaCPF++;
            Frm_ValidaCPF_UC U = new Frm_ValidaCPF_UC();
            U.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = $"Valida CPF {this.ControleValidaCPF}";
            TB.Text = $"Valida CPF {this.ControleValidaCPF}";
            TB.ImageIndex = 3;
            TB.Controls.Add(U);

            Tbc_Aplicacoes.TabPages.Add(TB); ;
        }

        private void validaCPF2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ControleValidaCPF2++;
            Frm_ValidaCPF2_UC U = new Frm_ValidaCPF2_UC();
            U.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = $"Valida CPF2 {this.ControleValidaCPF2}";
            TB.Text = $"Valida CPF2 {this.ControleValidaCPF2}";
            TB.ImageIndex = 4;
            TB.Controls.Add(U);

            Tbc_Aplicacoes.TabPages.Add(TB);
        }

        private void validaSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ControleChecaForcaSenha++;
            Frm_ValidaSenha_UC U = new Frm_ValidaSenha_UC();
            U.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = $"Valida Senha {this.ControleChecaForcaSenha}";
            TB.Text = $"Valida Senha {this.ControleChecaForcaSenha}";
            TB.ImageIndex = 5;
            TB.Controls.Add(U);

            Tbc_Aplicacoes.TabPages.Add(TB);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void apagarAbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tbc_Aplicacoes.SelectedTab != null)
            {
                Tbc_Aplicacoes.TabPages.Remove(Tbc_Aplicacoes.SelectedTab);
            }
        }

        private void sairToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void abrirImagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog db = new OpenFileDialog();
            db.InitialDirectory = "C:\\Users\\mario_junior\\OneDrive - HST CARD\\Documentos\\Cursos\\Alura\\WindowsForms\\WindowsForms-02\\WindowsForms\\Imagens";
            db.Filter = "PNG|*.PNG";
            db.Title = "Escolha a Imagem";

            if(db.ShowDialog() == DialogResult.OK)
            {
                string nomeArquivoImagem = db.FileName;

                this.ControleArquivoImagem++;
                Frm_ArquivoImagem_UC U = new Frm_ArquivoImagem_UC(nomeArquivoImagem);
                U.Dock = DockStyle.Fill;
                TabPage TB = new TabPage();
                TB.Name = $"Arquivo Imagem {this.ControleArquivoImagem}";
                TB.Text = $"Arquivo Imagem {this.ControleArquivoImagem}";
                TB.ImageIndex = 6;
                TB.Controls.Add(U);
                Tbc_Aplicacoes.TabPages.Add(TB);
            }

        }

        private void conectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Login form = new Frm_Login();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                string senha = form.Senha;
                string login = form.Login;

                if (Utils.ValidaSenhaLogin(senha))
                {
                    this.desconectarToolStripMenuItem.Enabled = true;
                    this.novoToolStripMenuItem.Enabled = true;
                    this.apagarAbaToolStripMenuItem.Enabled = true;
                    this.abrirImagemToolStripMenuItem.Enabled = true;
                    this.conectarToolStripMenuItem.Enabled = false;

                    MessageBox.Show($"Bem vindo(a) {login}!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Senha inválida!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void desconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Questao db = new Frm_Questao("icons8_ponto_de_interrogação_961", "Você deseja se desconectar?");
            db.ShowDialog();

            if (db.DialogResult == DialogResult.Yes)
            {
                for (int i = this.Tbc_Aplicacoes.TabPages.Count - 1; i >= 0; i--)
                {
                    this.Tbc_Aplicacoes.TabPages.RemoveAt(i);
                }
                this.desconectarToolStripMenuItem.Enabled = false;
                this.novoToolStripMenuItem.Enabled = false;
                this.apagarAbaToolStripMenuItem.Enabled = false;
                this.abrirImagemToolStripMenuItem.Enabled = false;
                this.conectarToolStripMenuItem.Enabled = true;
            }
        }

        private void Tbc_Aplicacoes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var contextMenu = new ContextMenuStrip();
                var toolTip001 = DesenhaItemMenu("Apagar Aba", "DeleteTab");
                var toolTip002 = DesenhaItemMenu("Apagar Todas a Esquerda", "DeleteLeft");
                var toolTip003 = DesenhaItemMenu("Apagar Todas a Direita", "DeleteRight");
                var toolTip004 = DesenhaItemMenu("Apagar Todas Menos Esta", "DeleteAll");
                contextMenu.Items.Add(toolTip001);
                contextMenu.Items.Add(toolTip002);
                contextMenu.Items.Add(toolTip003);
                contextMenu.Items.Add(toolTip004);

                contextMenu.Show(this, new Point(e.X, e.Y));
                toolTip001.Click += new System.EventHandler(toolTip001_Click);
                toolTip002.Click += new System.EventHandler(toolTip002_Click);
                toolTip003.Click += new System.EventHandler(toolTip003_Click);
                toolTip004.Click += new System.EventHandler(toolTip004_Click);
            }
        }

        private void toolTip001_Click(object sender, EventArgs e)
        {
            if (Tbc_Aplicacoes.SelectedTab != null)
            {
                Tbc_Aplicacoes.TabPages.Remove(Tbc_Aplicacoes.SelectedTab);
            }
        }

        private void toolTip002_Click(object sender, EventArgs e)
        {
            this.ApagaEsquerda(this.Tbc_Aplicacoes.SelectedIndex);
           
        }
        private void toolTip003_Click(object sender, EventArgs e)
        {
            this.ApagaDireita(this.Tbc_Aplicacoes.SelectedIndex);
        }

        private void toolTip004_Click(object sender, EventArgs e)
        {
            this.ApagaEsquerda(this.Tbc_Aplicacoes.SelectedIndex);
            this.ApagaDireita(this.Tbc_Aplicacoes.SelectedIndex);
        }

        static private ToolStripMenuItem DesenhaItemMenu(string text, string nomeImagem)
        {
            var toolTipResult = new ToolStripMenuItem();
            Image myImage = (Image)global::WindowsForms.Properties.Resources.ResourceManager.GetObject(nomeImagem);
            toolTipResult.Image = myImage;
            toolTipResult.Text = text;

            return toolTipResult;
        }

        private void ApagaEsquerda(int itemSelecionado)
        {
            for (int i = itemSelecionado - 1; i >= 0; i--)
            {
                this.Tbc_Aplicacoes.TabPages.RemoveAt(i);
            }
        }

        private void ApagaDireita(int itemSelecionado)
        {
            for (int i = this.Tbc_Aplicacoes.TabPages.Count - 1; i > itemSelecionado; i--)
            {
                this.Tbc_Aplicacoes.TabPages.RemoveAt(i);
            }
        }
    }
}
