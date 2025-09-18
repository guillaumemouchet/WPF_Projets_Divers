
using System.Windows;
using System.Windows.Controls;

namespace WpfApplicationRevisions
{
    public class MyCustomControl : Control
    {
        public static readonly DependencyProperty LabelProperty =
        DependencyProperty.Register(
            nameof(Label),               // Nom
            typeof(string),              // Type
            typeof(MyCustomControl),     // Classe propriétaire
            new PropertyMetadata("Default") // Valeur par défaut
        );


        //Création d'un Label selon mes enives et mes contrôles Permet plus de mobilité d'affichage
        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        static MyCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl),
                new FrameworkPropertyMetadata(typeof(MyCustomControl)));
        }
    }
}
