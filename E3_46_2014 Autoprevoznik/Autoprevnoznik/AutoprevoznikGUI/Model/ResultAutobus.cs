using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoprevoznikGUI.Model
{
    public class ResultAutobus
    {
        public int reg { get; set; }
        public string model { get; set; }
        public int br_mesta { get; set; }
        public DateTime dat_reg { get; set; }
        public int hours { get; set; }

        public ResultAutobus() { }
    }
}
