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
    public partial class Form_PencilWidth : Form
    {
        public Form_Main form_Main;
        public static Point currentLocation;
        static int trackValue;

        public Form_PencilWidth(Form_Main f)
        {
            InitializeComponent();

            form_Main = f;
            trackBar1.Value = trackValue;
        }

        private void Form_PencilWidth_Load(object sender, EventArgs e)
        {
            Location = currentLocation;
        }

        private void Form_PencilWidth_FormClosed(object sender, FormClosedEventArgs e)
        {
            form_Main.Enabled = true;
            currentLocation = Location;
            trackValue = trackBar1.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackValue = trackBar1.Value;
            form_Main.pencilWidth = trackValue;
        }
    }
}
