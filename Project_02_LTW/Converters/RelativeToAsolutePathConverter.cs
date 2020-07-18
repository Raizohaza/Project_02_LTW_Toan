﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Project_02_LTW.Converters
{
    public class RelativeToAsolutePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var relative = value.ToString();
            if (relative.Contains(":\\"))
                return relative;
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            var absolute = $"{folder}imageeeee\\{relative}";
            return absolute;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
