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
    public partial class Form_Main : Form
    {
        Cursor cursorPencil = new Cursor("Images\\pencil.cur");
        Cursor[] cursorEraser = new Cursor[3];
        byte indexCursorEraser = 0;
        public float pencilWidth = 20;
        List<Point> points;
        public Color colorOfWhiteSpace = Color.White;
        Color pencilColor = Color.FromArgb(128, 0, 255);
        public Perseptron perseptron;
        string fileNameOfPerseptronMemory = "memory.dat";
        public string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Form_Main()
        {
            InitializeComponent();

            cursorEraser[0] = new Cursor("Images\\eraser_Small.cur");
            cursorEraser[1] = new Cursor("Images\\eraser_Middle.cur");
            cursorEraser[2] = new Cursor("Images\\eraser_Big.cur");

            pictureBox1.BackColor = colorOfWhiteSpace;
            pictureBox1.Cursor = cursorPencil;

            var bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            var g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(colorOfWhiteSpace), new Rectangle(new Point(), pictureBox1.Size));
            pictureBox1.Image = bmp;

            points = new List<Point>();
            perseptron = new Perseptron(fileNameOfPerseptronMemory, alphabet.Length, pictureBox1.Size.Width * pictureBox1.Size.Height + 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form_Recognition.currentLocation = Location;
            Form_PencilWidth.currentLocation = Location;
            Form_Sensitivity.currentLocation = Location;
        }

        private void button_Recognition_Click(object sender, EventArgs e)
        {    
            this.Visible = false;
            Form_Recognition form_Recognition = new Form_Recognition(this);

            form_Recognition.Visible = true;
            form_Recognition.pictureBox1.Image = pictureBox1.Image;
            form_Recognition.Cursor = Cursors.WaitCursor;
            form_Recognition.Enabled = false;

            //read matrix of signals            
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            List<bool> signals = new List<bool>();            
            signals.Add(true);
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    signals.Add( bmp.GetPixel(j, i).ToArgb() != colorOfWhiteSpace.ToArgb() );
                }
            }
            bmp.Dispose();

            //Recognize
            var resultOfRecognize = perseptron.Recognize(signals);

            //show result
            string strResultOfRecognize = "";
            for (int i = 0; i < resultOfRecognize.Count; i++)
            {
                //if (resultOfRecognize[i] >= 0.8)
                if (resultOfRecognize[i] >= 0.5)
                    strResultOfRecognize = strResultOfRecognize + alphabet[i] + " ";
            }
            Color colorResultOfRecognize = strResultOfRecognize.Length == 0 ? Color.Red : Color.Green;
            if (strResultOfRecognize.Length == 0)
                strResultOfRecognize = "Не розпізнано";
            form_Recognition.label_Result.Text = strResultOfRecognize;
            form_Recognition.label_Result.ForeColor = colorResultOfRecognize;
            

            form_Recognition.Cursor = Cursors.Default;
            form_Recognition.Enabled = true;
        }

        private void button_Pencil_Click(object sender, EventArgs e)
        {
            pictureBox1.Cursor = cursorPencil;
        }

        private void button_Eraser_Click(object sender, EventArgs e)
        {
            pictureBox1.Cursor = cursorEraser[indexCursorEraser];
        }
                
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {            
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                points.Add(new Point(e.X + 5, e.Y + 25));
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            points = new List<Point>();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (points.Count > 3 && pictureBox1.Cursor == cursorPencil)
            {
                var bitmap = new Bitmap(pictureBox1.Image);
                var graphics = Graphics.FromImage(bitmap);

                using (var p = new Pen(pencilColor, pencilWidth))
                {
                    graphics.DrawCurve(p, points.ToArray());                
                }
                  
                pictureBox1.Image = bitmap;
                graphics.Dispose();
                points.RemoveRange(0, points.Count - 3);
            }
            else if (points.Count > 0 && pictureBox1.Cursor == cursorEraser[indexCursorEraser])
            {
                var bitmap = new Bitmap(pictureBox1.Image);
                var graphics = Graphics.FromImage(bitmap);

                float sizeEraser = indexCursorEraser == 0 ? 12 : indexCursorEraser == 1 ? 22 : 32;
                foreach (var item in points)
                {
                    graphics.FillRectangle(new SolidBrush(colorOfWhiteSpace), item.X - sizeEraser / 2 + 11, item.Y - sizeEraser / 2 - 10, sizeEraser, sizeEraser);
                }

                pictureBox1.Image = bitmap;
                graphics.Dispose();
                points.Clear();
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(pictureBox1.Image);
            var graphics = Graphics.FromImage(bitmap);

            graphics.FillRectangle(new SolidBrush(colorOfWhiteSpace), new Rectangle(new Point(), pictureBox1.Size));

            pictureBox1.Image = bitmap;
            graphics.Dispose();
        }

        private void розмірОлівцяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form_PencilWidth(this);
            this.Enabled = false;
            f.Visible = true;
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                pencilColor = colorDialog1.Color;
        }

        private void маленькаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            indexCursorEraser = 0;
            pictureBox1.Cursor = cursorEraser[0];
        }

        private void середняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            indexCursorEraser = 1;
            pictureBox1.Cursor = cursorEraser[1];
        }

        private void великаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            indexCursorEraser = 2;
            pictureBox1.Cursor = cursorEraser[2];
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                points.Add(new Point(e.X + 5, e.Y + 25));
                pictureBox1.Invalidate();
            }
        }

        private void Form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            perseptron.SaveToFile(fileNameOfPerseptronMemory);
        }

        private void вийтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Sensitivity f = new Form_Sensitivity(this);
            this.Enabled = false;
            f.Show();
        }

        private void вийтиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            perseptron.SaveToFile(fileNameOfPerseptronMemory);
        }

        private void вийтиToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        


    }    
}
