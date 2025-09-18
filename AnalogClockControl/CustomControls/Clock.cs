using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace AnalogClockControl.CustomControls
{

    /// <summary>
    /// Separation de ce qui est une horloge et ce qui est d'une horloge
    /// Dans cette classe il n'y a que la logique niveau heure
    /// </summary>
    [TemplateVisualState(Name = "Day", GroupName = "TimeStat")]
    [TemplateVisualState(Name = "Night", GroupName = "TimeStat")]
    public class Clock : Control
    {

        //Utilisation de DependencyProperty pour le stockage du temps, permet des animations et du binding                                                                                                                 //Fait planter le programme sinon                     
        public static readonly DependencyProperty TimeClockProperty = DependencyProperty.Register("TimeClock", typeof(DateTime), typeof(Clock), new PropertyMetadata(DateTime.Now, TimePropertyChanged, TimeCoerceValue)); //, TimeValidateValue);





        //Delegate décrit la signature de la méthode que tu aimerais passer

        //Création d'une DependencyProperty qui a comme "variable" ShowSeconds boolean
        public static readonly DependencyProperty ShowSecondsProperty = DependencyProperty.Register("ShowSeconds", typeof(bool), typeof(Clock), new PropertyMetadata(true));
        public static readonly RoutedEvent TimeChangedEvent = EventManager.RegisterRoutedEvent("TimeChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<DateTime>), typeof(Clock)); //Le nom du Registred Routed Event doit correspondre au nom de l'event .NET

        public DateTime TimeClock //Le nom de la Property doit être égal à ce qui a été mis dans le Register
        {
            get { return (DateTime)GetValue(TimeClockProperty); }
            set { SetValue(TimeClockProperty, value); }
        }

        public bool ShowSeconds //Le nom de la Property doit être égal à ce qui a été mis dans le Register
        {
            get { return (bool)GetValue(ShowSecondsProperty); }
            set { SetValue(ShowSecondsProperty, value); }
        }

        public event RoutedPropertyChangedEventHandler<DateTime> TimeChanged
        {
            add
            {
                AddHandler(TimeChangedEvent, value);
            }
            remove
            {
                RemoveHandler(TimeChangedEvent, value);
            }
        }

        public override void OnApplyTemplate()
        {
            //Timer Creation
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1); //EverySecond
            timer.Tick += (s, e) => OnTimeChanged(DateTime.Now);
            timer.Start();
            base.OnApplyTemplate();
        }

        protected virtual void OnTimeChanged(DateTime time)
        {
            UpdateTimeStyle(time);
            //RaiseEvent(new RoutedPropertyChangedEventArgs<DateTime>(TimeClock, time, TimeChangedEvent)); // on utilise un type généric qui nous évite de passer par une autre classe
            //ça demande jsute une ancienne valeur et une nouvelle valeur (non sauvegardé dans notre contexte donc on met 0)
            //Ce qui fait que les Handler et les Args sont des types génériques.

            TimeClock = time;
            //RaiseEvent(new TimeChangedEventArgs(TimeChangedEvent, this) { Time =time}); //Première solution ou on crée sa propre classe pour gérer les arguments, couteux en place pour paas grand chose
            //Attention aussi changer les autres Handler pour des TimeChangedEventHandler

        }


        private void UpdateTimeStyle(DateTime time)
        {
            if (time.Hour > 6 && time.Hour < 18)
            {
                VisualStateManager.GoToState(this, "Day", false); //Xaml utilise le state pour changer le style
            }
            else
            {
                VisualStateManager.GoToState(this, "Night", false);
            }
        }

        //Creation du delegate, ils sont static afin de pouvoir être référencé- appelà a chaque TimeClockProperty
        private static void TimePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //Il faut convertir d à notre objet (this)
            if (d is Clock)
            {
                Clock clock = d as Clock;
                //On change selon les noms du delegate mais pas de nos noms qu'on utilise
                clock.RaiseEvent(new RoutedPropertyChangedEventArgs<DateTime>((DateTime)e.OldValue, (DateTime)e.NewValue, TimeChangedEvent)); // on utilise un type généric qui nous évite de passer par une autre classe
            }
        }

        //Appelée avant le TimePropoertyChanged qui est le callback de la méthode deleguée, permet de controler la value avant de passer dans le delegate
        //Ce qui lève une erreur et ne permet pas la continuation
        private static bool TimeValidateValue(object value)
        {
            if (value is DateTime)
            {
                DateTime dt = (DateTime)(value);

                if (dt.Second % 2 == 1)
                {
                    return false;
                }
            }
            return true;
        }

        //Look a lot like the validate
        //Dans le coerce On peut modifier la valeur pour qu'elle passe la validation et que le programme continue son execution
        //On change notre contenue pour avoir que des secondes paires (ça ne fait aucun sens mais c'est pour l'exercice)
        private static object TimeCoerceValue(DependencyObject d, object baseValue)
        {
            if (baseValue is DateTime)
            {
                DateTime dt = (DateTime)(baseValue);

                if (dt.Second % 2 == 1)
                {
                    baseValue = dt.AddSeconds(1);
                }
            }
            return baseValue;
        }
    }
}
