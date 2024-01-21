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
        public Neiron neiron;
        string fileNameOfNeironMemory = "memory.dat";

        public Form_Main()
        {
            InitializeComponent();

            cursorEraser[0] = new Cursor("Images\\eraser_Small.cur");
            cursorEraser[1] = new Cursor("Images\\eraser_Middle.cur");
            cursorEraser[2] = new Cursor("Images\\eraser_Big.cur");

            pictureBox1.BackColor = colorOfWhiteSpace;
            pictureBox1.Cursor = cursorPencil;            
            pictureBox1.Image = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);

            points = new List<Point>();
            neiron = new Neiron(fileNameOfNeironMemory, pictureBox1.Image.Height, pictureBox1.Image.Width);
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
            form_Recognition.button_Right.Enabled = false;
            form_Recognition.button_Wrong.Enabled = false;
            form_Recognition.pictureBox2.Enabled = false;
            form_Recognition.pictureBox3.Enabled = false;
            form_Recognition.pictureBox1.Image = pictureBox1.Image;
            form_Recognition.Cursor = Cursors.WaitCursor;

            //read matrix of signals
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            bool[,] signals = new bool[bmp.Height, bmp.Width];
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    signals[i,j] = !(bmp.GetPixel(j, i).ToArgb() == colorOfWhiteSpace.ToArgb());
                }
            }
            bmp.Dispose();

            //Recognize
            bool resultOfRecognize = neiron.Recognize(signals);

            //show result
            string strResultOfRecognize = resultOfRecognize ? "Парне" : "Непарне";
            Color colorResultOfRecognize = resultOfRecognize ? Color.Green : Color.Red;
            form_Recognition.label_Result.Text = strResultOfRecognize;
            form_Recognition.label_Result.ForeColor = colorResultOfRecognize;
            

            form_Recognition.button_Right.Enabled = true;
            form_Recognition.button_Wrong.Enabled = true;
            form_Recognition.pictureBox2.Enabled = true;
            form_Recognition.pictureBox3.Enabled = true;
            form_Recognition.Cursor = Cursors.Default;
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
            neiron.SaveToFile(fileNameOfNeironMemory);
        }

        private void вийтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Sensitivity f = new Form_Sensitivity(this);
            this.Enabled = false;
            f.Show();
        }

        private void вийтиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            neiron.SaveToFile(fileNameOfNeironMemory);
        }

        private void вийтиToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        


    }    
}
