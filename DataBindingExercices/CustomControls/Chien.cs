using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingExercices.CustomControls
{
    public class Chien
    {
        public string race;
        public string Race
        {
            get { return race; }
            set { race = value; }
        }

        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return $"{Name} ({Race})";
        }
    }
}
