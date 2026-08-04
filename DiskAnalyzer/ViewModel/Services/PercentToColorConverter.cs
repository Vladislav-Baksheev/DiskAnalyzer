using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DiskAnalyzer;

public class PercentToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int percent)
        {
            if (percent < 60) return new SolidColorBrush(Color.FromRgb(76, 175, 80));   
            if (percent < 80) return new SolidColorBrush(Color.FromRgb(255, 193, 7));   
            if (percent < 90) return new SolidColorBrush(Color.FromRgb(255, 152, 0));   
            return new SolidColorBrush(Color.FromRgb(244, 67, 54));                     
        }
        return new SolidColorBrush(Color.FromRgb(33, 150, 243));
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}