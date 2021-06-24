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
    /// Interaction logic for AELinijaView.xaml
    /// </summary>
    public partial class AELinijaView : Window
    {
        public static AELinijaView view;
        public AELinijaView(bool function, LinijaViewModel linijaVM)
        {
            InitializeComponent();
            view = this;
            DataContext = new AELinijaViewModel(function, linijaVM);
        }

        public AELinijaView(bool function, Linija selected, LinijaViewModel linijaVM)
        {
            InitializeComponent();
            view = this;
            DataContext = new AELinijaViewModel(function, selected, linijaVM);
        }

    }
}
