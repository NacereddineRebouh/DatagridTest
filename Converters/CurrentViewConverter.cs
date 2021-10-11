using DatagridTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DatagridTest.Converters
{
    public class CurrentViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BaseViewModel baseViewModel = (BaseViewModel)value;
            Debug.WriteLine(baseViewModel.GetType() + " pp :" + parameter.ToString());
            if (parameter.ToString() == "home")
            {
                if (baseViewModel.GetType().Equals(new HomeViewModel().GetType()))
                {
                    Debug.WriteLine("in");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (baseViewModel.GetType().Equals(new UsersViewModel().GetType()))
                {
                    Debug.WriteLine("in");
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
