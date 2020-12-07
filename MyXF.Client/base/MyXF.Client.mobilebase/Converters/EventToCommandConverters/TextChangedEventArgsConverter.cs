using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyXF.Client.mobilebase.Converters.EventToCommandConverters
{
    public class TextChangedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is TextChangedEventArgs eventArgs))
                throw new ArgumentException("Expected TextChangedEventArgs as value", "value");

            return eventArgs.NewTextValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}