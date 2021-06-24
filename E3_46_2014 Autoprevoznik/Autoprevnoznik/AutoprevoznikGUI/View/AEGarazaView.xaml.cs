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
    /// Interaction logic for AEGarazaView.xaml
    /// </summary>
    public partial class AEGarazaView : Window
    {
        public static AEGarazaView view;
        public AEGarazaView(bool function, GarazaViewModel garazaVM)
        {
            InitializeComponent();
            view = this;
            DataContext = new AEGarazaViewModel(function, garazaVM);
        }

        public AEGarazaView(bool function, Garaza selected, GarazaViewModel garazaVM)
        {
            InitializeComponent();
            view = this;
            DataContext = new AEGarazaViewModel(function, selected, garazaVM);
        }

    }
}
