using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_7
{
    public partial class Form1 : Form
    {
        System.Threading.Thread threadLight = null;

        Bitmap loadedBitmap = null;
        MyColor[,] loadedBitmapPixels = null;

        List<Figure> figureList = new List<Figure>();
        Random random = new Random();

        Bitmap ChangeBitmap()
        {
            Bitmap tempBitmap = null;
            if (loadedBitmap != null)
            {
                tempBitmap = new Bitmap(loadedBitmapPixels.GetLength(1), loadedBitmapPixels.GetLength(0));
                double multiplierRed = (double)trackBar1.Value / 100;
                double multiplierGreen = (double)trackBar2.Value / 100;
                double multiplierBlue = (double)trackBar3.Value / 100;
                double multiplierAlpha = (double)trackBar4.Value / 100;

                for (int i = 0; i < tempBitmap.Width; i++)
                {
                    for (int j = 0; j < tempBitmap.Height; j++)
                    {
                        short red = (short)(loadedBitmapPixels[j, i].R + loadedBitmapPixels[j, i].R * multiplierRed);
                        short green = (short)(loadedBitmapPixels[j, i].G + loadedBitmapPixels[j, i].G * multiplierGreen);
                        short blue = (short)(loadedBitmapPixels[j, i].B + loadedBitmapPixels[j, i].B * multiplierBlue);
                        short alpha = (short)(loadedBitmapPixels[j, i].A + loadedBitmapPixels[j, i].A * multiplierAlpha);

                        if (red < 0)
                            red = 0;
                        if (red > 255)
                            red = 255;

                        if (green < 0)
                            green = 0;
                        if (green > 255)
                            green = 255;

                        if (blue < 0)
                            blue = 0;
                        if (blue > 255)
                            blue = 255;

                        if (alpha < 0)
                            alpha = 0;
                        if (alpha > 255)
                            alpha = 255;

                        Color newColor = Color.FromArgb((byte)alpha, (byte)red, (byte)green, (byte)blue);
                        tempBitmap.SetPixel(i, j, newColor);
                    }
                }
            }
            return tempBitmap;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            завданняToolStripMenuItem.Text = "Завдання_1";            
            AcceptButton = button1;
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            завданняToolStripMenuItem.Text = "Завдання_2"; 
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            завданняToolStripMenuItem.Text = "Завдання_3";
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
        }
                
        private void button1_Click(object sender, EventArgs e)
        {
            if (!maskedTextBox1.MaskCompleted || !maskedTextBox2.MaskCompleted || !maskedTextBox3.MaskCompleted)
                MessageBox.Show("Заповніть поля цілими числами", "Неправильне введення", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int timeRed = int.Parse(maskedTextBox1.Text);
                int timeYellow = int.Parse(maskedTextBox2.Text);
                int timeGreen = int.Parse(maskedTextBox3.Text);

                TrafficLight trafficLight = new TrafficLight(timeRed, timeYellow, timeGreen, pictureBox1);

                if (threadLight != null && threadLight.IsAlive)
                    threadLight.Abort();
                threadLight = new System.Threading.Thread(trafficLight.TurnOnTrafficLight);
                threadLight.IsBackground = true;
                threadLight.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AcceptButton = button1;
            panel2.Visible = false;
            panel3.Visible = false;
            panel1.Visible = true;

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics.FromImage(bmp).FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics.FromImage(bmp).FillRectangle(Brushes.White, 0, 0, pictureBox2.Width, pictureBox2.Height);
            pictureBox2.Image = bmp;
            bmp = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            Graphics.FromImage(bmp).FillRectangle(Brushes.White, 0, 0, pictureBox3.Width, pictureBox3.Height);
            pictureBox3.Image = bmp;
            bmp = new Bitmap(pictureBox4.Width, pictureBox4.Height);
            Graphics.FromImage(bmp).FillRectangle(Brushes.Violet, 0, 0, pictureBox4.Width, pictureBox4.Height);
            pictureBox4.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPEG|*.jpg|Bitmap|*.bmp|PNG|*.png|GIF|*.gif|Image files|*.jpg;*.bmp;*.png;*.gif";
            openFileDialog1.FilterIndex = 5;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadedBitmap = new Bitmap(openFileDialog1.FileName);
                loadedBitmapPixels = new MyColor[loadedBitmap.Height, loadedBitmap.Width];
                for (int i = 0; i < loadedBitmap.Width; i++)
                {
                    for (int j = 0; j < loadedBitmap.Height; j++)
                    {
                        loadedBitmapPixels[j, i] = new MyColor(loadedBitmap.GetPixel(i, j));
                    }
                }
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Image = loadedBitmap;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (loadedBitmap != null)
            {
                Bitmap tempBitmap = ChangeBitmap();
                
                saveFileDialog1.FileName = "image.png";
                saveFileDialog1.Filter = "JPEG|*.jpg|Bitmap|*.bmp|PNG|*.png|All files|*.*";
                saveFileDialog1.FilterIndex = 3;
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    tempBitmap.Save(saveFileDialog1.FileName);
            }
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = ChangeBitmap();
        }

        private void trackBar1_KeyUp(object sender, KeyEventArgs e)
        {
            pictureBox2.Image = ChangeBitmap();
        }

        private void trackBar2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = ChangeBitmap();
        }

        private void trackBar2_KeyUp(object sender, KeyEventArgs e)
        {
            pictureBox2.Image = ChangeBitmap();
        }

        private void trackBar3_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = ChangeBitmap();
        }

        private void trackBar3_KeyUp(object sender, KeyEventArgs e)
        {
            pictureBox2.Image = ChangeBitmap();
        }

        private void trackBar4_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = ChangeBitmap();
        }

        private void trackBar4_KeyUp(object sender, KeyEventArgs e)
        {
            pictureBox2.Image = ChangeBitmap();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            trackBar1.Value = trackBar2.Value = trackBar3.Value = trackBar4.Value = 0;
            pictureBox2.Image = ChangeBitmap();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!maskedTextBox4.MaskCompleted)
                MessageBox.Show("Заповніть вірно поле " + (radioButton1.Checked ? "'Радіус'" : "'Сторона'"), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (radioButton1.Checked)
                {
                    figureList.Add(new Circle(Convert.ToDouble(maskedTextBox4.Text), new Point(random.Next(pictureBox3.Width), random.Next(pictureBox3.Height)), new Bitmap(pictureBox4.Image).GetPixel(0, 0), textBox1.Text));
                    figureList[figureList.Count-1].DrawToPictureBox(pictureBox3);
                }
                else if (radioButton2.Checked)
                {
                    figureList.Add(new Square(Convert.ToDouble(maskedTextBox4.Text), new Point(random.Next(pictureBox3.Width), random.Next(pictureBox3.Height)), new Bitmap(pictureBox4.Image).GetPixel(0, 0), textBox1.Text));
                    figureList[figureList.Count - 1].DrawToPictureBox(pictureBox3);
                }
                else if (radioButton3.Checked)
                {
                    figureList.Add(new EquilateralTriangle(Convert.ToDouble(maskedTextBox4.Text), new Point(random.Next(pictureBox3.Width), random.Next(pictureBox3.Height)), new Bitmap(pictureBox4.Image).GetPixel(0, 0), textBox1.Text));
                    figureList[figureList.Count - 1].DrawToPictureBox(pictureBox3);
                }
                else if (radioButton4.Checked)
                {
                    figureList.Add(new HexagonalStar(Convert.ToDouble(maskedTextBox4.Text), new Point(random.Next(pictureBox3.Width), random.Next(pictureBox3.Height)), new Bitmap(pictureBox4.Image).GetPixel(0, 0), textBox1.Text));
                    figureList[figureList.Count - 1].DrawToPictureBox(pictureBox3);
                }

                comboBox1.Items.Clear();
                for (int i = 0; i < figureList.Count; i++)
                {
                    comboBox1.Items.Add(i.ToString() + " " + figureList[i].GetType() + " " + figureList[i].Color.ToString() + " " + figureList[i].Text);
                }
                comboBox1.Text = comboBox1.Items[comboBox1.Items.Count - 1].ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            Graphics.FromImage(bmp).Clear(Color.White);
            pictureBox3.Image = bmp;
            figureList.Clear();

            comboBox1.Items.Clear();
            comboBox1.Text = "";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                label10.Text = "Радіус";
            else
                label10.Text = "Сторона";
        }
        
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                label10.Text = "Радіус";
            else
                label10.Text = "Сторона";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                label10.Text = "Радіус";
            else
                label10.Text = "Сторона";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                label10.Text = "Радіус";
            else
                label10.Text = "Сторона";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {            
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(pictureBox4.Width, pictureBox4.Height);
                Graphics.FromImage(bmp).FillRectangle(new SolidBrush(colorDialog1.Color), 0, 0, pictureBox4.Width, pictureBox4.Height);
                pictureBox4.Image = bmp;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Contains(comboBox1.Text))
            {
                string index = "";
                
                int i = 0;
                while (comboBox1.Text[i] != ' ')
                {
                    index += comboBox1.Text[i];
                    i++;
                }
                
                figureList.RemoveAt(Convert.ToInt32(index));
                
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                for (int j = 0; j < figureList.Count; j++)
                {
                    comboBox1.Items.Add(j.ToString() + " " + figureList[j].GetType() + " " + figureList[j].Color.ToString() + " " + figureList[j].Text);
                }
                if (comboBox1.Items.Count > 0)
                    comboBox1.Text = comboBox1.Items[comboBox1.Items.Count - 1].ToString();

                Bitmap bmp = new Bitmap(pictureBox3.Width, pictureBox3.Height);
                Graphics.FromImage(bmp).Clear(Color.White);
                pictureBox3.Image = bmp;

                foreach (var item in figureList)
                {
                    item.DrawToPictureBox(pictureBox3);
                }
            }
        }        
    }    
}