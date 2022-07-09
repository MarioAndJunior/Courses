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
    public partial class Frm_DemonstracaoKey : Form
    {
        private static readonly int[] KonamiCode = { 38, 38, 40, 40, 37, 39, 37, 39, 66, 65 };
        private List<int> sequence = new List<int>();
        public Frm_DemonstracaoKey()
        {
            InitializeComponent();
        }

        private void Txt_Input_KeyDown(object sender, KeyEventArgs e)
        {
            this.Txt_Msg.AppendText("\r\n + Pressionei uma tecla: " + e.KeyCode + "\r\n");
            this.Txt_Msg.AppendText("\t Código da tecla: " + (int)e.KeyCode + "\r\n");
            this.Txt_Msg.AppendText("\t Nome da tecla: " + e.KeyData + "\r\n");

            this.Lbl_Lower.Text = e.KeyCode.ToString().ToLower();
            this.Lbl_Upper.Text = e.KeyCode.ToString().ToUpper();

            this.sequence.Add((int)e.KeyCode);

            if (this.sequence.Count == KonamiCode.Length)
            {
                if (this.sequence.SequenceEqual(KonamiCode))
                {
                    this.Txt_Msg.Text = string.Empty;
                    this.Txt_Input.Text = string.Empty;
                    this.Lbl_Upper.Text = string.Empty;
                    this.Lbl_Lower.Text = string.Empty;

                    this.Txt_Msg.Text = "Oh Yeah!!!!!!!!\r\n The Secret Code";

                    this.sequence.Clear();
                }
                else
                {
                    this.sequence.Clear();
                }

            }
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            this.Txt_Msg.Text = string.Empty;
            this.Txt_Input.Text = string.Empty;
            this.Lbl_Upper.Text = string.Empty;
            this.Lbl_Lower.Text = string.Empty;
        }
    }
}
