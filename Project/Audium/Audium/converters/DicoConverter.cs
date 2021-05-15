using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Donnees;
using Gestionnaires;

namespace Audium.converters
{
    class DicoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Dictionary<EnsembleAudio, LinkedList<Piste>> dico = value as Dictionary<EnsembleAudio, LinkedList<Piste>>;
            return dico;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
