using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoprevoznikGUI.Model
{
     public class TabeleVKKEntity
    {
        public int Mbr { get; set; }
        public int Id { get; set; }

        public int Karta { get; set; }

        public int Linija { get; set; }

        public DateTime Polazak { get; set; }
        public string Naselje { get; set; }


        public TabeleVKKEntity() { }
    }
}
