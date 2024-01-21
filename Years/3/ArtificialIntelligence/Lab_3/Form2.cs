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

        private void DoEducation(List<bool> desireResponse)
        {
            this.Cursor = Cursors.WaitCursor;
            form_Main.perseptron.Education(desireResponse);
            this.Cursor = Cursors.Default;

            var bmp = new Bitmap(form_Main.pictureBox1.Image);
            var g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(form_Main.colorOfWhiteSpace), new Rectangle(new Point(), bmp.Size));
            form_Main.pictureBox1.Image = bmp;
            g.Dispose();

            this.Close(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('Q')] = true;
            DoEducation(desireResponse);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('W')] = true;
            DoEducation(desireResponse);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('E')] = true;
            DoEducation(desireResponse);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('R')] = true;
            DoEducation(desireResponse);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('T')] = true;
            DoEducation(desireResponse);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('Y')] = true;
            DoEducation(desireResponse);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('U')] = true;
            DoEducation(desireResponse);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('I')] = true;
            DoEducation(desireResponse);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('O')] = true;
            DoEducation(desireResponse);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('P')] = true;
            DoEducation(desireResponse);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('A')] = true;
            DoEducation(desireResponse);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('S')] = true;
            DoEducation(desireResponse);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('D')] = true;
            DoEducation(desireResponse);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('F')] = true;
            DoEducation(desireResponse);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('G')] = true;
            DoEducation(desireResponse);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('H')] = true;
            DoEducation(desireResponse);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('J')] = true;
            DoEducation(desireResponse);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('K')] = true;
            DoEducation(desireResponse);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('L')] = true;
            DoEducation(desireResponse);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('Z')] = true;
            DoEducation(desireResponse);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('X')] = true;
            DoEducation(desireResponse);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('C')] = true;
            DoEducation(desireResponse);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('V')] = true;
            DoEducation(desireResponse);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('B')] = true;
            DoEducation(desireResponse);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('N')] = true;
            DoEducation(desireResponse);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            var desireResponse = new List<bool>();
            for (int i = 0; i < form_Main.alphabet.Length; i++)
                desireResponse.Add(false);
            desireResponse[form_Main.alphabet.IndexOf('M')] = true;
            DoEducation(desireResponse);
        }

    }
}
