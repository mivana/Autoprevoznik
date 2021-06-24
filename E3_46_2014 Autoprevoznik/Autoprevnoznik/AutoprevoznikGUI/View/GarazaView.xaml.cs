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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoprevoznikGUI.View
{
    /// <summary>
    /// Interaction logic for GarazaView.xaml
    /// </summary>
    public partial class GarazaView : UserControl
    {
        public static GarazaView view;
        public GarazaView()
        {
            InitializeComponent();
            view = this;
            DataContext = new GarazaViewModel();
        }
    }
}
