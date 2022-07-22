using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace Colors
{
    public class MyColor
    {
        int _alpha;
        int _red;
        int _green;
        int _blue;
        public int Alpha { get =>_alpha; set => _alpha = value; }
        public int Red { get => _red; set => _red = value; }
        public int Green { get => _green; set => _green = value; }
        public int Blue {  get =>_blue; set => _blue = value; }

        SolidColorBrush _brush;

        public MyColor(int a, int r, int g, int b) {
            _alpha = a;
            _red = r;
            _green = g;
            _blue = b;
            _brush = new SolidColorBrush(Color.FromArgb((byte)_alpha, (byte)_red, (byte)_green, (byte)_blue));
        }

        public MyColor() {
            _alpha = 0;
            _red = 0;
            _green = 0;
            _blue = 0;
        }

        public SolidColorBrush MyBrush { get => _brush; set => _brush = value; }

        public string MyBrushFormat { get => _brush.ToString(); }
    }
}
