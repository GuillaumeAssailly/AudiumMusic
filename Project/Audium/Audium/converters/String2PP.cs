using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Audium.converters
{
    class String2PP : IValueConverter
    {

        private static string imagesPath;

        static String2PP()
        {
            imagesPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\img\PP");
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageName = value as string;
            
            string imagePath = Path.Combine(imagesPath, imageName);
            if (!File.Exists(imagePath))
            {
                return new Uri(Path.Combine(imagesPath, @"..\icondefault\pp.png"), UriKind.RelativeOrAbsolute);
            }
            return new Uri(imagePath, UriKind.RelativeOrAbsolute);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
