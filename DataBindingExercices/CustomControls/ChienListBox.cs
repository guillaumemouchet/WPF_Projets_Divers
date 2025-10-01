using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataBindingExercices.CustomControls
{

    public class ChienListBox
    {
        public ObservableCollection<Chien> Chiens { get; set; }
        public Chien chien = new Chien() { Name = "Damien", Race = "Dalmacien" };

        public ChienListBox()
        {
            Chiens = new ObservableCollection<Chien>
            {
                new Chien() { Name = "Adrien", Race = "Albinos" },
                new Chien() { Name = "Bastien", Race = "Berger anglais" },
                new Chien() { Name = "Camille", Race = "Chien" },
                chien
            };
              
        }
    }
}
