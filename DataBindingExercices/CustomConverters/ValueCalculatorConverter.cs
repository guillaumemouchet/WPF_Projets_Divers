using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DataBindingExercices.CustomConverters
{
    public class ValueCalculatorConverter : IMultiValueConverter
    {
        //Convertisseur sans trop de protection mais on fait deja comme ça, pas de controle de saisie pour l'instant
        //Ce n'est pas grave car il a uniquement un but d'affichage et non de traitement des données.
        //Il permet un affichage et traitement rapide mais sans pouvoir utiliser le resultat
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values != null && values.Length == 2 &&//Checking that we have a Number 1 et Number 2
                double.TryParse(values[0].ToString(), out double nb0) && //Convert the values to double instead
                double.TryParse(values[1].ToString(), out double nb1) ?
                String.Format("{0}", nb0 * nb1) : // if both gives a values we multiply
                String.Format("{0}", 0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
