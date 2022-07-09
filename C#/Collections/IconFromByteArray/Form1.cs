using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IconFromByteArray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap bm = new Bitmap(32, 32);
            MemoryStream memoryStream;

            using(Stream stream = new FileStream("favicon.ico", FileMode.Open, FileAccess.Read))
	        {
                memoryStream = new MemoryStream();
                byte[] buffer = new byte[1024];
                int byteCount = 0;

                do
                {
                    byteCount = stream.Read(buffer, 0, buffer.Length);
                    memoryStream.Write(buffer, 0, byteCount);
                } while (byteCount > 0);

                bm = new Bitmap(Image.FromStream(memoryStream));
                Icon icon = Icon.FromHandle(bm.GetHicon());
                this.Icon = icon;
	        }
        }
    }
}
