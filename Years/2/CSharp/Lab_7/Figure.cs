using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab_7
{
    public abstract class Figure
    {
        public string Text { get; set; }
        public Color Color { get; set; }
        protected Point position = new Point(0, 0);

        public abstract void DrawToPictureBox(PictureBox pictureBox);
        public abstract void MoveTo(int x, int y);
    }

    public class Circle : Figure
    {
        public double Radius { get; set; }

        public Circle(double _radius, Point _position, Color _color, string _text)
        {
            Radius = _radius;
            if (_position != null)
            {
                position.X = _position.X;
                position.Y = _position.Y;
            }
            Color = _color;
            Text = _text;
        }

        public override void MoveTo(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

        public override void DrawToPictureBox(PictureBox pictureBox)
        {
            Bitmap bmp;
            if (pictureBox.Image != null)
                bmp = new Bitmap(pictureBox.Image);
            else
                bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.DrawEllipse(new Pen(Color, 2), (int) (position.X - Radius), (int) (position.Y - Radius), (int) (Radius * 2), (int) (Radius * 2));
            graphics.DrawString(Text, new Font(FontFamily.GenericSansSerif, 8), Brushes.Black, position.X - Text.Length/2*6, position.Y-4);
            pictureBox.Image = bmp;
        }
    }

    public class Square : Figure
    {
        public double Side { get; set; }

        public Square(double _side, Point _position, Color _color, string _text)
        {
            Side = _side;
            if (_position != null)
            {
                position.X = _position.X;
                position.Y = _position.Y;
            }
            Color = _color;
            Text = _text;
        }

        public override void MoveTo(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

        public override void DrawToPictureBox(PictureBox pictureBox)
        {
            Bitmap bmp;
            if (pictureBox.Image != null)
                bmp = new Bitmap(pictureBox.Image);
            else
                bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.DrawRectangle(new Pen(Color, 2), (int) (position.X - Side/2), (int) (position.Y - Side/2), (int) (Side), (int) (Side));
            graphics.DrawString(Text, new Font(FontFamily.GenericSansSerif, 8), Brushes.Black, position.X-Text.Length/2*6, position.Y-4);
            pictureBox.Image = bmp;
        }
    }

    public class EquilateralTriangle : Figure
    {
        public double Side { get; set; }

        public EquilateralTriangle(double _side, Point _position, Color _color, string _text)
        {
            Side = _side;
            if (_position != null)
            {
                position.X = _position.X;
                position.Y = _position.Y;
            }
            Color = _color;
            Text = _text;
        }

        public override void MoveTo(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

        public override void DrawToPictureBox(PictureBox pictureBox)
        {
            Bitmap bmp;
            if (pictureBox.Image != null)
                bmp = new Bitmap(pictureBox.Image);
            else
                bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            double h = Side * (Math.Sqrt(3)/2);
            Point[] points = new Point[3];
            points[0] = new Point(position.X, (int)(position.Y-h/2));
            points[1] = new Point((int)(position.X+Side/2), (int)(position.Y+h/2));
            points[2] = new Point((int)(position.X-Side/2), (int)(position.Y+h/2));
            graphics.DrawPolygon(new Pen(Color, 2), points);
            graphics.DrawString(Text, new Font(FontFamily.GenericSansSerif, 8), Brushes.Black, position.X-Text.Length/2*6, position.Y-4);
            pictureBox.Image = bmp;
        }
    }

    public class HexagonalStar : Figure
    {
        public double Side { get; set; }

        public HexagonalStar(double _side, Point _position, Color _color, string _text)
        {
            Side = _side;
            if (_position != null)
            {
                position.X = _position.X;
                position.Y = _position.Y;
            }
            Color = _color;
            Text = _text;
        }

        public override void MoveTo(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

        public override void DrawToPictureBox(PictureBox pictureBox)
        {
            Bitmap bmp;
            if (pictureBox.Image != null)
                bmp = new Bitmap(pictureBox.Image);
            else
                bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            double h = Side * (Math.Sqrt(3)/2);
            Point[] points = new Point[3];
            points[0] = new Point(position.X, (int)(position.Y-h*2));
            points[1] = new Point((int)(position.X+Side+Side/2), (int)(position.Y+h));
            points[2] = new Point((int)(position.X-Side-Side/2), (int)(position.Y+h));
            graphics.DrawPolygon(new Pen(Color, 2), points);
            points[0] = new Point(position.X, (int)(position.Y + h*2));
            points[1] = new Point((int)(position.X + Side + Side / 2), (int)(position.Y - h));
            points[2] = new Point((int)(position.X - Side - Side / 2), (int)(position.Y - h));
            graphics.DrawPolygon(new Pen(Color, 2), points);
            graphics.DrawString(Text, new Font(FontFamily.GenericSansSerif, 8), Brushes.Black, position.X-Text.Length/2*6, position.Y-4);
            pictureBox.Image = bmp;
        }
    }
}