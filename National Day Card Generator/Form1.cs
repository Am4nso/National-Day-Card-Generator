using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace National_Day_Card_Generator
{
    public partial class Form1 : Form
    {
        private PrivateFontCollection foo = new PrivateFontCollection();

        private Font font;

        private Bitmap bmp;

        public Form1()
        {
            foo.AddFontFile("Roboto-Regular.ttf");

            font = new Font(foo.Families[0], 18f);

            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textBox1.Enabled = false;
            string name = textBox1.Text;

            if (string.IsNullOrEmpty(name))
            {
                button1.Enabled = true;
                textBox1.Enabled = true;
                return;
            }

            bmp = new Bitmap(Properties.Resources.CARD);

            Graphics g = Graphics.FromImage(bmp);

            g.DrawString(name, font, Brushes.Black, 129, (float)303.5);

            button2.Visible = true;

            label8.Visible = true;

            button1.Enabled = true;

            textBox1.Clear();

            textBox1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Images|*.png;*.bmp;*.jpg"
            };

            ImageFormat format = ImageFormat.Png;

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }

                bmp.Save(sfd.FileName, format);
            }

        }
    }
}
