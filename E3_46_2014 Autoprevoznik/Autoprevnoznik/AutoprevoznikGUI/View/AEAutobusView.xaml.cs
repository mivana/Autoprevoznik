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
    /// Interaction logic for AEAutobusView.xaml
    /// </summary>
    public partial class AEAutobusView : Window
    {
        public static AEAutobusView view;
        public AEAutobusView(bool function, AutobusViewModel autobusVM)
        {
            InitializeComponent();
            view = this;
            DataContext = new AEAutobusViewModel(function, autobusVM);
        }

        public AEAutobusView(bool function, Autobu selected, AutobusViewModel autobusVM)
        {
            InitializeComponent();
            view = this;
            DataContext = new AEAutobusViewModel(function, selected, autobusVM);
        }

    }
}
