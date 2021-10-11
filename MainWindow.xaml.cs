using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatagridTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            //RadioButton Item = sender as RadioButton;
            //double h = 20;
            //ControlTemplate i = Item.Template;
            //Rectangle selection_Rectangle = i.FindName("selection_Rectangle", Item) as Rectangle;
            //var mousePoint = Mouse.GetPosition(Item);
            //DoubleAnimation Height = null;
            //if (Item.IsChecked == true)
            //{
            //    Height = new DoubleAnimation(0, h, new Duration(TimeSpan.FromSeconds(0.2)));
            //}
            //else
            //{
            //    Height = new DoubleAnimation(h, 0, new Duration(TimeSpan.FromSeconds(0.2)));
            //}

            //Storyboard sb = new Storyboard();
            //Storyboard.SetTarget(Height, selection_Rectangle);
            //Storyboard.SetTargetProperty(Height, new PropertyPath(HeightProperty));

            //QuadraticEase qe = new QuadraticEase();
            //qe.EasingMode = EasingMode.EaseOut;
            //Height.EasingFunction = qe;

            //sb.Children.Add(Height);
            //sb.Begin(this);
        }

        private void uc_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!((FrameworkElement)e.Source).Name.Equals("Sidemenu"))
            {

                if (Sidemenu.toggle.IsChecked == true)
                {
                    Sidemenu.toggle.IsChecked = false;
                }

            }

        }
    }
}
