using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_7
{
    public class MyColor
    {
        public byte A { get; set; }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public MyColor(Color color)
        {
            A = color.A;
            R = color.R;
            G = color.G;
            B = color.B;
        }

        public static implicit operator Color(MyColor myColor)
        {
            return Color.FromArgb(myColor.A, myColor.R, myColor.G, myColor.B);
        }

        public static implicit operator MyColor(Color color)
        {
            return new MyColor(color);
        }
    }
}