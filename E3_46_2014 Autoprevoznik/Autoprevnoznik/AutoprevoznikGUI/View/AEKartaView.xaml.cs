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
    /// Interaction logic for AEKartaView.xaml
    /// </summary>
    public partial class AEKartaView : Window
    {
        public static AEKartaView view;
        public AEKartaView(bool function, KartaViewModel kartaVM)
        {
            InitializeComponent();
            view = this;
            DataContext = new AEKartaViewModel(function, kartaVM);
        }

        public AEKartaView(bool function, Karta selected, KartaViewModel kartaVM)
        {
            InitializeComponent();
            view = this;
            DataContext = new AEKartaViewModel(function, selected, kartaVM);
        }

    }
}
