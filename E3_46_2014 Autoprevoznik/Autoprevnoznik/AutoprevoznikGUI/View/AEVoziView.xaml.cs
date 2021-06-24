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
    /// Interaction logic for AEVoziView.xaml
    /// </summary>
    public partial class AEVoziView : Window
    {
        public static AEVoziView view;
        public AEVoziView(Vozac selected,VozacViewModel model)
        {
            InitializeComponent();
            view = this;
            DataContext = new AEVoziViewModel(selected, model);
        }
    }
}
 