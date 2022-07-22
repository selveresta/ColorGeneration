using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Colors;

namespace Colors
{
    public static class ColorRepository
    {
        static ObservableCollection<MyColor> _colors;

        public static ObservableCollection<MyColor> ListColors
        {
            get
            {
                if (_colors == null)
                    _colors = GenerateContactRepository();
                return _colors;
            }
        }

        static ObservableCollection<MyColor> GenerateContactRepository()
        {
            var tmp = new ObservableCollection<MyColor> {
                new MyColor(255, 125,111,87),
                new MyColor(255, 54, 98, 87),
                new MyColor(255, 65,133,12),
                new MyColor(255, 78,111,87),
            };
            return tmp;
        }
    }
}
