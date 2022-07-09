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
    public partial class Frm_Menu_Flutuante : Form
    {
        public Frm_Menu_Flutuante()
        {
            InitializeComponent();
        }

        private void Frm_Menu_Flutuante_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //var posX = e.X;
                //var posY = e.Y;
                //MessageBox.Show($"Cliquei com botão da direita do mouse.\nA posição relativa foi X: {posX.ToString()} e Y: {posY.ToString()}");
                var contextMenu = new ContextMenuStrip();
                var toolTip001 = DesenhaItemMenu("Item do menu 1", "key");
                var toolTip002 = DesenhaItemMenu("Item do menu 2", "Frm_ValidaSenha");
                contextMenu.Items.Add(toolTip001);
                contextMenu.Items.Add(toolTip002);

                contextMenu.Show(this, new Point(e.X, e.Y));
                toolTip001.Click += new System.EventHandler(toolTip001_Click);
                toolTip002.Click += new System.EventHandler(toolTip002_Click);

                //var contextMenu = new ContextMenuStrip();
                //var toolStripMenu001 = new ToolStripMenuItem();
                //toolStripMenu001.Text = "Menu 1";
                //var toolStripItem011 = new ToolStripMenuItem();
                //var toolStripItem012 = new ToolStripMenuItem();
                //toolStripItem011.Text = "Menu 1.1";
                //toolStripItem012.Text = "Menu 1.2";
                //toolStripMenu001.DropDownItems.Add(toolStripItem011);
                //toolStripMenu001.DropDownItems.Add(toolStripItem012);

                //var toolStripMenu002 = new ToolStripMenuItem();
                //toolStripMenu002.Text = "Menu 2";
                //var toolStripMenu003 = new ToolStripMenuItem();
                //toolStripMenu003.Text = "Menu 3";

                //contextMenu.Items.Add(toolStripMenu001);
                //contextMenu.Items.Add(toolStripMenu002);
                //contextMenu.Items.Add(toolStripMenu003);
            }
        }

        private void toolTip001_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selecionei a opção do menu 001");
        }

        private void toolTip002_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selecionei a opção do menu 002");
        }

        static private ToolStripMenuItem DesenhaItemMenu(string text, string nomeImagem)
        {
            var toolTipResult = new ToolStripMenuItem();
            Image myImage = (Image)global::WindowsForms.Properties.Resources.ResourceManager.GetObject(nomeImagem);
            toolTipResult.Image = myImage;
            toolTipResult.Text = text;

            return toolTipResult;
        }
    }
}
