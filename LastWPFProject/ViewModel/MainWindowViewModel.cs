using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Colors;
using LastWPFProject.Infrastructure;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Win32;

namespace LastWPFProject.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        MyColor _color;
        MyColor _selectedcolor;
        public event PropertyChangedEventHandler PropertyChanged;
        SolidColorBrush _viewColor;
        DelegateCom addColorCommand;
        DelegateCom delColorCommand;
        DelegateCom saveColorCommand;

        public ObservableCollection<MyColor> Colors { get; set; } // for list box

        public MyColor ColorInList
        {
            get => _selectedcolor;
            set
            {
                if (_selectedcolor != value)
                {
                    _selectedcolor = value;
                    OnPropertyChanged();
                }
            }
        }


        public MainWindowViewModel() {
            _color = new MyColor();
            Colors = ColorRepository.ListColors;
        }

        public DelegateCom AddColorCommand
        {
            get
            {
                return addColorCommand ?? (
                        addColorCommand = new DelegateCom(obj =>
                        {
                            MyColor tmp = new MyColor(_color.Alpha, _color.Red, _color.Green, _color.Blue);
                            Colors.Add(tmp);
                        })
                    );
            }
        }

        public DelegateCom DelColorCommand
        {
            get
            {
                return delColorCommand ?? (
                        delColorCommand = new DelegateCom(obj =>
                        {
                            //MessageBox.Show(ColorInList.MyBrushFormat);
                            if (ColorInList != null)
                                Colors.Remove(ColorInList);

                        })
                    );
            }
        }

        public DelegateCom SaveColorCommand
        {
            get
            {
                return saveColorCommand ?? (
                        saveColorCommand = new DelegateCom(obj =>
                        {
                            //XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<MyColor>));
                            //var win = new SaveFileDialog();
                            ////win.ShowDialog();
                            //using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
                            //{
                            //    serializer.Serialize(fs, Colors);
                            //}
                        })
                    );
            }
        }



        public MyColor SelectedColor { get => _color; 
            set {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Alpha { get => _color.Alpha;
            set {
                if (_color.Alpha != value)
                {
                    _color.Alpha = value;
                    OnPropertyChanged();
                    ViewColor = new SolidColorBrush(Color.FromArgb((byte)_color.Alpha, (byte)_color.Red, (byte)_color.Green, (byte)_color.Blue));
                }
            }
        }

        public int Red
        {
            get => _color.Red;
            set
            {
                if (_color.Red != value)
                {
                    _color.Red = value;
                    OnPropertyChanged();
                    ViewColor = new SolidColorBrush(Color.FromArgb((byte)_color.Alpha, (byte)_color.Red, (byte)_color.Green, (byte)_color.Blue));
                }
            }
        }

        public int Green
        {
            get => _color.Green;
            set
            {
                if (_color.Green != value)
                {
                    _color.Green = value;
                    OnPropertyChanged();
                    ViewColor = new SolidColorBrush(Color.FromArgb((byte)_color.Alpha, (byte)_color.Red, (byte)_color.Green, (byte)_color.Blue));
                }
            }
        }

        public int Blue
        {
            get => _color.Blue;
            set
            {
                if (_color.Blue != value)
                {
                    _color.Blue = value;
                    OnPropertyChanged();
                    ViewColor = new SolidColorBrush(Color.FromArgb((byte)_color.Alpha, (byte)_color.Red, (byte)_color.Green, (byte)_color.Blue));
                }
            }
        }

        public SolidColorBrush ViewColor { 
            get {
                return _viewColor;
            }
            set
            {
                if (_viewColor != value)
                {
                    _viewColor = value;
                    OnPropertyChanged();
                }
            }
        }

        void OnPropertyChanged([CallerMemberName] string name = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
