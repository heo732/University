using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class Form_Recognition : Form
    {
        public Form_Main form_Main;

        public static Point currentLocation;

        public Form_Recognition(Form_Main f)
        {
            InitializeComponent();

            form_Main = f;
        }

        private void Form_Recognition_FormClosed(object sender, FormClosedEventArgs e)
        {
            form_Main.Visible = true;
            currentLocation = Location;
        }

        private void Form_Recognition_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = form_Main.colorOfWhiteSpace;
            Location = currentLocation;
        }

        private void button_Right_Click(object sender, EventArgs e)
        {
            var bmp = new Bitmap(form_Main.pictureBox1.Image);
            var g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(form_Main.colorOfWhiteSpace), new Rectangle(new Point(), bmp.Size));
            form_Main.pictureBox1.Image = bmp;
            g.Dispose();

            this.Close();
        }

        private void button_Wrong_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            form_Main.neiron.Education();
            this.Cursor = Cursors.Default;

            var bmp = new Bitmap(form_Main.pictureBox1.Image);
            var g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(form_Main.colorOfWhiteSpace), new Rectangle(new Point(), bmp.Size));
            form_Main.pictureBox1.Image = bmp;
            g.Dispose();
            
            this.Close();
        }

       
    }
}
