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
    public partial class Frm_Login : Form
    {
        public string Senha { get; private set; }
        public string Login { get; private set; }
        public Frm_Login()
        {
            InitializeComponent();

            this.Lbl_Login.Text = "Usuário";
            this.Lbl_Password.Text = "Senha";
            this.Btn_Cancel.Text = "Cancela";
            this.Btn_OK.Text = "OK";
        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Login = this.Txt_Login.Text;
            this.Senha = this.Txt_Password.Text;
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
