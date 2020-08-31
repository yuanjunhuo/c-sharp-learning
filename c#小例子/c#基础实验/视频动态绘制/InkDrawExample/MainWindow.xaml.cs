using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Ink;
using System.IO;
using InkDrawExample.MyInks;

namespace InkDrawExample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DrawingAttributes inkDA1 = new DrawingAttributes()
            {
                Color = Colors.Orange,
                Height = 6,
                Width = 6,
                FitToCurve = false
            };
            myinkcanvas.DefaultDrawingAttributes = inkDA1;
            myinkcanvas.EditingMode = InkCanvasEditingMode.Ink;
        }
        private void RibbonRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RibbonRadioButton rrb = e.Source as RibbonRadioButton;
            string rrbLabel = rrb.Label;
            switch (rrbLabel)
            {
                case "球形":
                    myinkcanvas.selectShape = "球形";
                    InkEllipseDynamic myDynamic1 = new InkEllipseDynamic();
                    myinkcanvas.setDyanmic(myDynamic1);
                    break;
                case "矩形":
                    myinkcanvas.selectShape = "矩形";
                    InkRectangleDynamic myDynamic2 = new InkRectangleDynamic();
                    myinkcanvas.setDyanmic(myDynamic2);
                    break;
                case "视频":
                    myinkcanvas.selectShape = "视频";
                    InkViedoDynamic mydynamic3 = new InkViedoDynamic();
                    myinkcanvas.setDyanmic(mydynamic3);
                    break;
            }
        }

        private void RibbonApplicationMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        public void ChangeSelect(string selectedName)
        {
           
        }

        public void OnAppMenuItemClick(string name)
        {

        }
    }
}
