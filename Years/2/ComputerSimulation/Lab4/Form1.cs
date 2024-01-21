using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.All;
            chart2.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.All;

            AcceptButton = button1;
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            пункт1ToolStripMenuItem.Text = "Пункт_1";
            AcceptButton = button1;
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            пункт1ToolStripMenuItem.Text = "Пункт_2";
            AcceptButton = button1;
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            double lambda = 0;
            if (Int32.TryParse(textBox1.Text, out count) && Double.TryParse(textBox2.Text, out lambda))
            {
                double[] tau = new double[count];                
                for (int i = 0; i < tau.Length; i++)
                {
                    tau[i] = Rozpodily.rozpodil_5_Exp(lambda);
                }

                int[] y = new int[count + 1];
                double[] x = new double[count + 1];
                x[0] = 0;
                y[0] = 0;
                for (int i = 0; i < tau.Length; i++)
                {
                    y[i+1] = i+1;
                    x[i+1] = x[i] + tau[i];
                }

                //chart1
                chart1.ChartAreas.Clear();
                chart1.Legends.Clear();
                chart1.Annotations.Clear();
                chart1.Titles.Clear();
                chart1.Series.Clear();


                chart1.Series.Add("Task1 markers");
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series[0].BorderColor = Color.Empty;
                chart1.Series[0].Color = Color.Black;
                chart1.Series[0].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                chart1.Series[0].Points.DataBindXY(x, y);


                chart1.ChartAreas.Add("Час натходження заявок");

                chart1.ChartAreas[0].AxisX.Minimum = -5;
                chart1.ChartAreas[0].AxisX.Maximum = (int) (x[x.Length-1] + 1) + 5;
                chart1.ChartAreas[0].AxisY.Minimum = -5;
                chart1.ChartAreas[0].AxisY.Maximum = count + 5;

                chart1.ChartAreas[0].AxisX.Interval = ((int)(x[x.Length - 1] + 1) + 10) / 8;
                chart1.ChartAreas[0].AxisY.Interval = (count + 10) / 8;

                chart1.ChartAreas[0].BackColor = Color.FromArgb(240, 240, 240);
                chart1.ChartAreas[0].AxisX.LineColor = Color.White;
                chart1.ChartAreas[0].AxisY.LineColor = Color.White;
                chart1.ChartAreas[0].AxisX.InterlacedColor = Color.White;
                chart1.ChartAreas[0].AxisY.InterlacedColor = Color.White;
                chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;
                chart1.ChartAreas[0].AxisX.Title = "Час натходження заявок";
                chart1.ChartAreas[0].AxisX.TitleFont = new Font(FontFamily.GenericSansSerif, 12);
                chart1.ChartAreas[0].AxisY.Title = "Кількість заявок";
                chart1.ChartAreas[0].AxisY.TitleFont = new Font(FontFamily.GenericSansSerif, 12);
                chart1.ChartAreas[0].AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
                chart1.ChartAreas[0].AxisX.IntervalOffset = 5;
                chart1.ChartAreas[0].AxisY.IntervalOffset = 5;




                //chart2
                chart2.ChartAreas.Clear();
                chart2.Legends.Clear();
                chart2.Annotations.Clear();
                chart2.Titles.Clear();
                chart2.Series.Clear();




                /*
                chart2.Series.Add("");
                chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chart2.Series[0].BorderColor = Color.Empty;
                chart2.Series[0].Color = Color.Black;
                chart2.Series[0].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                chart2.Series[0].Points.DataBindXY(x, y);


                chart2.ChartAreas.Add("");

                chart2.ChartAreas[0].AxisX.Minimum = -5;
                chart2.ChartAreas[0].AxisX.Maximum = (int)(x[x.Length - 1] + 1) + 5;
                chart2.ChartAreas[0].AxisY.Minimum = -5;
                chart2.ChartAreas[0].AxisY.Maximum = count + 5;

                chart2.ChartAreas[0].AxisX.Interval = ((int)(x[x.Length - 1] + 1) + 10) / 8;
                chart2.ChartAreas[0].AxisY.Interval = (count + 10) / 8;

                chart2.ChartAreas[0].BackColor = Color.FromArgb(240, 240, 240);
                chart2.ChartAreas[0].AxisX.LineColor = Color.White;
                chart2.ChartAreas[0].AxisY.LineColor = Color.White;
                chart2.ChartAreas[0].AxisX.InterlacedColor = Color.White;
                chart2.ChartAreas[0].AxisY.InterlacedColor = Color.White;
                chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
                chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;
                chart2.ChartAreas[0].AxisX.Title = "Кількість заявок";
                chart2.ChartAreas[0].AxisX.TitleFont = new Font(FontFamily.GenericSansSerif, 12);
                chart2.ChartAreas[0].AxisY.Title = "Частота натходження";
                chart2.ChartAreas[0].AxisY.TitleFont = new Font(FontFamily.GenericSansSerif, 12);
                chart2.ChartAreas[0].AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
                chart2.ChartAreas[0].AxisX.IntervalOffset = 5;
                chart2.ChartAreas[0].AxisY.IntervalOffset = 5;
                 */
            }
        }
    }
}