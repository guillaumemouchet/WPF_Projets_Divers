using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingExercices
{
    public enum TestEnums
    {
        None = 0,
        [Description("Test of totally random Descritpion for Fraise")]
        Fraise,
        Perceuse,
        Plaquette,
        Meche,
        Disque
    }    
}
