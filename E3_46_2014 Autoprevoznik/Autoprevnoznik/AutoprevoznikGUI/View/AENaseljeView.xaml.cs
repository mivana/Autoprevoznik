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
    /// Interaction logic for AENaseljeView.xaml
    /// </summary>
    public partial class AENaseljeView : Window
    {
        public static AENaseljeView view;
        public AENaseljeView(bool function, NaseljeViewModel naseljeVM)
        {
            InitializeComponent();
            view = this;
            DataContext = new AENaseljeViewModel(function, naseljeVM);
        }

        public AENaseljeView(bool function, Naselje selected, NaseljeViewModel naseljeVM)
        {
            InitializeComponent();
            view = this;
            DataContext = new AENaseljeViewModel(function, selected, naseljeVM);
        }

    }
}
