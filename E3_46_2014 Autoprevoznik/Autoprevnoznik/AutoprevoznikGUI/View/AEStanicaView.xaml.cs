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
    /// Interaction logic for AEStanicaView.xaml
    /// </summary>
    public partial class AEStanicaView : Window
    {
        public static AEStanicaView view;
        public AEStanicaView(bool function, StanicaViewModel stanicaVM)
        {
            InitializeComponent();
            view = this;
            DataContext = new AEStanicaViewModel(function, stanicaVM);
        }

        public AEStanicaView(bool function, Stanica selected, StanicaViewModel stanicaVM)
        {
            InitializeComponent();
            view = this;
            DataContext = new AEStanicaViewModel(function, selected, stanicaVM);
        }
    }
}
