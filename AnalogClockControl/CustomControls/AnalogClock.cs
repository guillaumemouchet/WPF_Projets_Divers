using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AnalogClockControl.CustomControls
{
    public delegate void TimeChangedEventHandler(object sender, TimeChangedEventArgs e);


    /// <summary>
    /// Heritage des classes
    /// Une analogClock est une spécification des clocks
    /// Elle s'occupe de tout ce qui es de la logique pour afficher des bras des horloges
    /// Tout en faisant appel aux méthodes de la classe mère pour avoir la logique des heures
    /// </summary>
    [TemplatePart(Name = "lnHour", Type = typeof(Line))]
    [TemplatePart(Name = "lnMinute", Type = typeof(Line))]
    [TemplatePart(Name = "lnSecond", Type = typeof(Line))]

    public class AnalogClock : Clock
    {
        private Line lnHour;
        private Line lnMinute;
        private Line lnSecond;

        static AnalogClock()
        {
            /* Permet d'annoncer que l'affichage doit être contrôlé et revu par une autre manière*/
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnalogClock), new FrameworkPropertyMetadata(typeof(AnalogClock)));
        }

        /// <summary>
        /// Invoked whenever application code or internal processes (such as a rebuilding layout pass) call ApplyTemplate.
        /// In simplest terms, this means the method is called just before a UI element displays in your app. Override this method to influence the default post-template logic of a class.
        /// </summary>
        public override void OnApplyTemplate()
        {
            lnHour = (Line)Template.FindName("lnHour", this);
            lnMinute = (Line)Template.FindName("lnMinute", this);
            lnSecond = (Line)Template.FindName("lnSecond", this);


            //Bind the lnSecond to the Dependancy
            /*Binding showLnSecondBinding = new Binding
            {
                Path = new PropertyPath(nameof(ShowSeconds)),
                Source = this,
                Converter = new BooleanToVisibilityConverter()
            };

            lnSecond.SetBinding(VisibilityProperty, showLnSecondBinding);*/
            base.OnApplyTemplate();
        }

        protected override void OnTimeChanged(DateTime time)
        {
            UpdateHandAngles(time);
         
            base.OnTimeChanged(time); //Appel de la classe parent
        }
        //Update temps réel des mains de l'horloge
        private void UpdateHandAngles(DateTime time)
        {
            lnHour.RenderTransform = new RotateTransform((time.Hour / 12.0) * 360, 0.5, 0.5); //Rotation selon un cercle et le nombre d'heure qu'il existe (0.5,0.5) Centre sur l'origin
            lnMinute.RenderTransform = new RotateTransform((time.Minute / 60.0) * 360, 0.5, 0.5); //Rotation selon un cercle et le nombre de minute qu'il existe (0.5,0.5) Centre sur l'origin
            lnSecond.RenderTransform = new RotateTransform((time.Second / 60.0) * 360, 0.5, 0.5); //Rotation selon un cercle et le nombre de seconde qu'il existe (0.5,0.5) Centre sur l'origin
        }
    }
}
