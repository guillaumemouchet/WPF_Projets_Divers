using System.Windows;

namespace AnalogClockControl.CustomControls
{
    [TemplatePart(Name = "Colon", Type = typeof(UIElement))]
    public class DigitalClock : Clock
    {
        private UIElement colon;

        //Utilisation de DependencyProperty pour le stockage du temps, permet des animations et du binding
        public static DependencyProperty ColonBlinkProperty = DependencyProperty.Register("ColonBlink", typeof(bool), typeof(DigitalClock), new PropertyMetadata(true));

        public bool ColonBlink //Le nom de la Property doit être égal à ce qui a été mis dans le Register
        {
            get { return (bool)GetValue(ColonBlinkProperty); }
            set { SetValue(ColonBlinkProperty, value); }
        }

        static DigitalClock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DigitalClock), new FrameworkPropertyMetadata(typeof(DigitalClock)));

        }

        public override void OnApplyTemplate()
        {
            colon = (UIElement)Template.FindName("Colon", this);

            if (colon == null){
                MessageBox.Show("Empty colon, wasn't found and stayed null", "Error happend");
            }

            base.OnApplyTemplate();
        }

        protected override void OnTimeChanged(DateTime time)
        {
            if (colon != null)
            {
                if (ColonBlink && !ShowSeconds)
                {
                    colon.Visibility = colon.IsVisible ? Visibility.Hidden : Visibility.Visible;
                }
                else
                {
                    colon.Visibility = Visibility.Visible;
                }
                base.OnTimeChanged(time);
            }
        }
    }
}
