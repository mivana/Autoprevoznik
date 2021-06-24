using AutoprevoznikGUI.Model;
using AutoprevoznikGUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AutoprevoznikGUI.View
{
    /// <summary>
    /// Interaction logic for AEVozacView.xaml
    /// </summary>
    public partial class AEVozacView : Window
    {
        public static AEVozacView view;
        public AEVozacView(bool function, VozacViewModel autobusVM)
        {
            InitializeComponent();
            view = this;
            DataContext = new AEVozacViewModel(function, autobusVM);
        }

        public AEVozacView(bool function, Vozac selected, VozacViewModel autobusVM)
        {
            InitializeComponent();
            view = this;
            DataContext = new AEVozacViewModel(function, selected, autobusVM);
        }

    }
}
