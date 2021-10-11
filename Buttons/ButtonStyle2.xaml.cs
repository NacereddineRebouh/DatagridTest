using DatagridTest;
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

namespace DatagridTest.Buttons
{
    /// <summary>
    /// Interaction logic for ButtonStyle2.xaml
    /// </summary>
    public partial class ButtonStyle2 : UserControl
    {
        public ButtonStyle2()
        {

            InitializeComponent();

        }


        #region <----Dependencies---->

        public Brush ButtonBackground
        {
            get { return (Brush)GetValue(ButtonBackgroundProperty); }
            set { SetValue(ButtonBackgroundProperty, value); }
        }
        public static readonly DependencyProperty ButtonBackgroundProperty =
            DependencyProperty.Register(nameof(ButtonBackground), typeof(Brush), typeof(ButtonStyle2), new PropertyMetadata(Brushes.Transparent));

        public Brush selectionColor
        {
            get { return (Brush)GetValue(selectionColorProperty); }
            set { SetValue(selectionColorProperty, value); }
        }
        public static readonly DependencyProperty selectionColorProperty =
            DependencyProperty.Register(nameof(selectionColor), typeof(Brush), typeof(ButtonStyle2), new PropertyMetadata((SolidColorBrush)new BrushConverter().ConvertFrom("#FFF76C4C")));

        public Color HoverColor
        {
            get { return (Color)GetValue(HoverColorProperty); }
            set { SetValue(HoverColorProperty, value); }
        }
        public static readonly DependencyProperty HoverColorProperty =
            DependencyProperty.Register(nameof(HoverColor), typeof(Color), typeof(ButtonStyle2), new PropertyMetadata((Color)new ColorConverter().ConvertFrom("#FFFF00")));

        public ImageSource ButtonIcon
        {
            get { return (ImageSource)GetValue(ButtonIconIconProperty); }
            set { SetValue(ButtonIconIconProperty, value); }
        }

        public static readonly DependencyProperty ButtonIconIconProperty = DependencyProperty.Register(nameof(ButtonIcon), typeof(ImageSource), typeof(ButtonStyle2), new PropertyMetadata(null));

        public Visibility IconVisibility
        {
            get { return (Visibility)GetValue(IconVisibilityProperty); }
            set { SetValue(IconVisibilityProperty, value); }
        }
        public static readonly DependencyProperty IconVisibilityProperty =
            DependencyProperty.Register(nameof(IconVisibility), typeof(Visibility), typeof(ButtonStyle2), new PropertyMetadata(Visibility.Collapsed));

        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }
        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register(nameof(ButtonText), typeof(string), typeof(ButtonStyle2), new PropertyMetadata("Button 2"));

        public Point GradientOrigin
        {
            get { return (Point)GetValue(GradientOriginProperty); }
            set { SetValue(GradientOriginProperty, value); }
        }
        public static readonly DependencyProperty GradientOriginProperty =
            DependencyProperty.Register(nameof(GradientOrigin), typeof(Point), typeof(ButtonStyle2), new PropertyMetadata(new Point()));


        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(ButtonStyle2), new PropertyMetadata(null));

        public double SelectionHeight
        {
            get { return (double)GetValue(SelectionHeightProperty); }
            set { SetValue(SelectionHeightProperty, value); }
        }
        public static readonly DependencyProperty SelectionHeightProperty =
            DependencyProperty.Register(nameof(SelectionHeight), typeof(double), typeof(ButtonStyle2), new PropertyMetadata(30.0));

        public Visibility RectangleVisibility
        {
            get { return (Visibility)GetValue(RectangleVisibilityProperty); }
            set { SetValue(RectangleVisibilityProperty, value); }
        }
        public static readonly DependencyProperty RectangleVisibilityProperty =
            DependencyProperty.Register(nameof(RectangleVisibility), typeof(Visibility), typeof(ButtonStyle2), new PropertyMetadata(Visibility.Collapsed));


        #endregion



        private void uc_Click(object sender, RoutedEventArgs e)
        {
            #region Rectagle animation
            if (Item.IsChecked == true)
            {
                double h = ActualHeight - 10;
                if (ActualHeight < 40)
                {
                    h = 30;
                }
                ControlTemplate i = Item.Template;
                Rectangle selection_Rectangle = i.FindName("selection_Rectangle", Item) as Rectangle;
                var mousePoint = Mouse.GetPosition(Item);
                DoubleAnimation Height = new DoubleAnimation(0, h, new Duration(TimeSpan.FromSeconds(0.2)));

                Storyboard sb = new Storyboard();
                Storyboard.SetTarget(Height, selection_Rectangle);
                Storyboard.SetTargetProperty(Height, new PropertyPath(HeightProperty));

                QuadraticEase qe = new QuadraticEase();
                qe.EasingMode = EasingMode.EaseOut;
                Height.EasingFunction = qe;

                sb.Children.Add(Height);
                sb.Begin(this);

            }
            #endregion

        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            //Window parentWindow = Application.Current.MainWindow;
            //parentWindow.MouseMove += new MouseEventHandler(MainWindowMouseMoveHandler);
        }

        public void MainWindowMouseMoveHandler(object sender, MouseEventArgs e)
        {
            if (((MainWindow)sender).IsAncestorOf(this))
            {


                ControlTemplate i = Item.Template;
                RadialGradientBrush rd = i.FindName("brush", Item) as RadialGradientBrush;

                var position = e.GetPosition((MainWindow)sender);

                Point relativePoint = this.TransformToAncestor((MainWindow)sender).Transform(new Point(0, 0));
                position.X = position.X - relativePoint.X;
                position.Y = position.Y - relativePoint.Y;
                rd.GradientOrigin = position;
                rd.Center = position;
            }
        }
    }
}
