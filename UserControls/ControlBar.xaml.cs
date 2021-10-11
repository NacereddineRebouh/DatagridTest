using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DatagridTest.UserControls
{
    /// <summary>
    /// Interaction logic for ControlBar.xaml
    /// </summary>
    public partial class ControlBar : UserControl
    {
        public ControlBar()
        {
            DataContext = this;
            InitializeComponent();
        }

        #region <----Dependencies---->

        public string AppName
        {
            get { return (string)GetValue(AppNameProperty); }
            set { SetValue(AppNameProperty, value); }
        }
        public static readonly DependencyProperty AppNameProperty =
            DependencyProperty.Register(nameof(AppName), typeof(string), typeof(ControlBar), new PropertyMetadata("Test"));


        public Color ControlBackground
        {
            get { return (Color)GetValue(MyControlBackgroundProperty); }
            set { SetValue(MyControlBackgroundProperty, value); }
        }
        public static readonly DependencyProperty MyControlBackgroundProperty =
            DependencyProperty.Register(nameof(ControlBackground), typeof(Color), typeof(ControlBar), new PropertyMetadata(Colors.Salmon));


        #region <----Click Events---->

        public event RoutedEventHandler ExitClick
        {
            add { AddHandler(ExitClickEvent, value); }
            remove { RemoveHandler(ExitClickEvent, value); }
        }
        public static readonly RoutedEvent ExitClickEvent = EventManager.RegisterRoutedEvent(
            nameof(ExitClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ControlBar));


        public event RoutedEventHandler MaximizeClick
        {
            add { AddHandler(MaximizeClickEvent, value); }
            remove { RemoveHandler(MaximizeClickEvent, value); }
        }
        public static readonly RoutedEvent MaximizeClickEvent = EventManager.RegisterRoutedEvent(
            nameof(MaximizeClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ControlBar));


        public event RoutedEventHandler MinimizeClick
        {
            add { AddHandler(MinimizeClickEvent, value); }
            remove { RemoveHandler(MinimizeClickEvent, value); }
        }
        public static readonly RoutedEvent MinimizeClickEvent = EventManager.RegisterRoutedEvent(
            nameof(MinimizeClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ControlBar));

        //public event MouseButtonEventHandler mouseDown
        //{
        //    add { AddHandler(mouseDownEvent, value); }
        //    remove { RemoveHandler(mouseDownEvent, value); }
        //}
        //public static readonly RoutedEvent mouseDownEvent = EventManager.RegisterRoutedEvent(
        //    nameof(mouseDown), RoutingStrategy.Bubble, typeof(MouseButtonEventHandler), typeof(ControlBar));

        public event MouseButtonEventHandler mouseDown;

        #endregion




        #endregion


        #region <----Methods and Handlers---->
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Application.Current.MainWindow;
            parentWindow.Close();
            //RaiseEvent(new RoutedEventArgs(ExitClickEvent));
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Application.Current.MainWindow;
            if (parentWindow.WindowState == WindowState.Normal)
            {
                parentWindow.WindowState = WindowState.Maximized;
            }
            else if (parentWindow.WindowState == WindowState.Maximized)
            {
                parentWindow.WindowState = WindowState.Normal;
            }
            //RaiseEvent(new RoutedEventArgs(MaximizeClickEvent));
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Application.Current.MainWindow;
            parentWindow.WindowState = WindowState.Minimized;
            //RaiseEvent(new RoutedEventArgs(MinimizeClickEvent));
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window parentWindow = Application.Current.MainWindow;
            if (e.ClickCount == 2)
            {
                if (parentWindow.WindowState == WindowState.Maximized)
                {
                    parentWindow.WindowState = WindowState.Normal;
                }
                else
                {
                    parentWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight - 10;
                    parentWindow.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth - 10;
                    parentWindow.WindowState = WindowState.Maximized;
                    parentWindow.Top -= 50;
                    parentWindow.Left -= 100;
                }
            }
            else if (e.ClickCount == 1)
            {
                if (parentWindow.WindowState == WindowState.Normal)
                {
                    parentWindow.DragMove();
                }
                else
                {
                    parentWindow.WindowState = WindowState.Normal;
                    parentWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight - 10;
                    parentWindow.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth - 10;
                    Point p = e.GetPosition(parentWindow);
                    double x = p.X;
                    double y = p.Y;
                    parentWindow.Left = x - 100;
                    parentWindow.Top = y - 20;
                    parentWindow.DragMove();
                }

            }

        }

        #endregion
    }
}
