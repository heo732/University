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
    class TrafficLight
    {
        int timeRed = 5;
        int timeYellow = 2;
        int timeGreen = 5;
        PictureBox pictureBox = null;

        float x0_Red, y0_Red, x0_Yellow, y0_Yellow, x0_Green, y0_Green;
        float ellipseWidth, ellipseHeight;

        float width, height;
        float x0, y0;

        public TrafficLight(int timeRed, int timeYellow, int timeGreen, PictureBox pictureBox)
        {
            this.timeRed = timeRed;
            this.timeYellow = timeYellow;
            this.timeGreen = timeGreen;
            this.pictureBox = pictureBox;
            
            x0 = pictureBox.Width / 2;
            y0 = pictureBox.Height / 2;
            width = pictureBox.Width / 4 * 3;
            height = pictureBox.Height / 8 * 7;

            x0_Red = x0_Yellow = x0_Green = x0;
            y0_Red = y0 - height / 2 + height / 3 / 2;
            y0_Yellow = y0;
            y0_Green = y0 + height / 3;
            
            ellipseHeight = ellipseWidth = height / 3 * 0.9f;

            Bitmap bmp;
            if (pictureBox.Image != null)
                bmp = new Bitmap(pictureBox.Image);
            else
                bmp = new Bitmap(pictureBox.Width, pictureBox.Height);

            Graphics graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.White);

            graphics.FillRectangle(Brushes.Black, x0 - width / 2, y0 - height / 2, width, height);
            graphics.FillEllipse(Brushes.White, x0_Red - ellipseWidth / 2, y0_Red - ellipseHeight / 2, ellipseWidth, ellipseHeight);
            graphics.FillEllipse(Brushes.White, x0_Yellow - ellipseWidth / 2, y0_Yellow - ellipseHeight / 2, ellipseWidth, ellipseHeight);
            graphics.FillEllipse(Brushes.White, x0_Green - ellipseWidth / 2, y0_Green - ellipseHeight / 2, ellipseWidth, ellipseHeight);

            pictureBox.Image = bmp;
        }

        public void TurnOnTrafficLight()
        {
            Graphics graphics = pictureBox.CreateGraphics();
            while (true)
            {
                graphics.FillRectangle(Brushes.Black, x0 - width / 2, y0 - height / 2, width, height);
                graphics.FillEllipse(Brushes.White, x0_Red - ellipseWidth / 2, y0_Red - ellipseHeight / 2, ellipseWidth, ellipseHeight);
                graphics.FillEllipse(Brushes.White, x0_Yellow - ellipseWidth / 2, y0_Yellow - ellipseHeight / 2, ellipseWidth, ellipseHeight);
                graphics.FillEllipse(Brushes.White, x0_Green - ellipseWidth / 2, y0_Green - ellipseHeight / 2, ellipseWidth, ellipseHeight);

                graphics.FillEllipse(Brushes.Red, x0_Red - ellipseWidth / 2, y0_Red - ellipseHeight / 2, ellipseWidth, ellipseHeight);
                System.Threading.Thread.Sleep(timeRed * 1000);

                graphics.FillRectangle(Brushes.Black, x0 - width / 2, y0 - height / 2, width, height);
                graphics.FillEllipse(Brushes.White, x0_Red - ellipseWidth / 2, y0_Red - ellipseHeight / 2, ellipseWidth, ellipseHeight);
                graphics.FillEllipse(Brushes.White, x0_Yellow - ellipseWidth / 2, y0_Yellow - ellipseHeight / 2, ellipseWidth, ellipseHeight);
                graphics.FillEllipse(Brushes.White, x0_Green - ellipseWidth / 2, y0_Green - ellipseHeight / 2, ellipseWidth, ellipseHeight);

                graphics.FillEllipse(Brushes.Yellow, x0_Yellow - ellipseWidth / 2, y0_Yellow - ellipseHeight / 2, ellipseWidth, ellipseHeight);
                System.Threading.Thread.Sleep(timeYellow * 1000);

                graphics.FillRectangle(Brushes.Black, x0 - width / 2, y0 - height / 2, width, height);
                graphics.FillEllipse(Brushes.White, x0_Red - ellipseWidth / 2, y0_Red - ellipseHeight / 2, ellipseWidth, ellipseHeight);
                graphics.FillEllipse(Brushes.White, x0_Yellow - ellipseWidth / 2, y0_Yellow - ellipseHeight / 2, ellipseWidth, ellipseHeight);
                graphics.FillEllipse(Brushes.White, x0_Green - ellipseWidth / 2, y0_Green - ellipseHeight / 2, ellipseWidth, ellipseHeight);

                graphics.FillEllipse(Brushes.Green, x0_Green - ellipseWidth / 2, y0_Green - ellipseHeight / 2, ellipseWidth, ellipseHeight);
                System.Threading.Thread.Sleep(timeGreen * 1000);

                graphics.FillRectangle(Brushes.Black, x0 - width / 2, y0 - height / 2, width, height);
                graphics.FillEllipse(Brushes.White, x0_Red - ellipseWidth / 2, y0_Red - ellipseHeight / 2, ellipseWidth, ellipseHeight);
                graphics.FillEllipse(Brushes.White, x0_Yellow - ellipseWidth / 2, y0_Yellow - ellipseHeight / 2, ellipseWidth, ellipseHeight);
                graphics.FillEllipse(Brushes.White, x0_Green - ellipseWidth / 2, y0_Green - ellipseHeight / 2, ellipseWidth, ellipseHeight);

                graphics.FillEllipse(Brushes.Yellow, x0_Yellow - ellipseWidth / 2, y0_Yellow - ellipseHeight / 2, ellipseWidth, ellipseHeight);
                System.Threading.Thread.Sleep(timeYellow * 1000);
            }
        }
    }
}