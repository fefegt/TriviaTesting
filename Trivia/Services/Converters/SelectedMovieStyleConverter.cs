using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Model;

namespace Trivia.Services.Converters
{
    public class StateMovieStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if ((MovieState)value == MovieState.Selected)
                return Colors.Gray;
            else if ((MovieState)value == MovieState.Winner)
                return Colors.Green;
            else if ((MovieState)value == MovieState.SelectedLoss)
                return Colors.Red;
            else
                return Colors.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
