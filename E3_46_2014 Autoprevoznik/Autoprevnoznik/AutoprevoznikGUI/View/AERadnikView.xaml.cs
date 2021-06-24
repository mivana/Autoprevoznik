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
    /// Interaction logic for AERadnikView.xaml
    /// </summary>
    public partial class AERadnikView : Window
    {
        public static AERadnikView view;
        public AERadnikView(bool function, RadnikViewModel radnikVM)
        {
            InitializeComponent();
            view = this;
            DataContext = new AERadnikViewModel(function, radnikVM);
        }

        public AERadnikView(bool function, Radnik selected, RadnikViewModel radnikVM)
        {
            InitializeComponent();
            view = this;
            DataContext = new AERadnikViewModel(function, selected, radnikVM);
        }

    }
}
