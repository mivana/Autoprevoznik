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
    /// Interaction logic for PutnikView.xaml
    /// </summary>
    public partial class PutnikView : UserControl
    {
        public static PutnikView view;
        public PutnikView()
        {
            InitializeComponent();
            view = this;
            DataContext = new PutnikViewModel();
        }
    }
}
