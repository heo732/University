using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_5
{
    public partial class Form_Linear : Form
    {
        Form1 formMain;

        public Form_Linear(Form1 formMain)
        {
            InitializeComponent();

            this.formMain = formMain;
            formMain.Enabled = false;
            numericUpDown1.Text = formMain.sygmoid_Alpha.ToString();
        }

        private void Form_Sygmoid_FormClosing(object sender, FormClosingEventArgs e)
        {
            formMain.sygmoid_Alpha = double.Parse(numericUpDown1.Text);

            formMain.Enabled = true;
        }
    }
}
