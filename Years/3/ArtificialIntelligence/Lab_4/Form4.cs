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
    public partial class Form_Sensitivity : Form
    {
        Form_Main form_Main;

        public static Point currentLocation;

        public Form_Sensitivity(Form_Main f)
        {
            InitializeComponent();

            form_Main = f;
        }

        private void Form_Sensitivity_Load(object sender, EventArgs e)
        {
            Location = currentLocation;
            label_Epoch.Text = form_Main.perseptron.GetEpoch().ToString();
            textBox1.Text = form_Main.perseptron.CoefficientOfEducationSpeed.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double value;
            if (double.TryParse(textBox1.Text, out value))
            {
                form_Main.perseptron.CoefficientOfEducationSpeed = value;
            }
            else
                MessageBox.Show("Введіть дійсне значення!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Form_Sensitivity_FormClosed(object sender, FormClosedEventArgs e)
        {
            form_Main.Enabled = true;
            currentLocation = Location;
        }
    }
}
