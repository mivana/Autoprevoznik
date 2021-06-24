﻿using AutoprevoznikGUI.Model;
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
    /// Interaction logic for AEPutnikView.xaml
    /// </summary>
    public partial class AEPutnikView : Window
    {
        public static AEPutnikView view;
        public AEPutnikView(bool function, PutnikViewModel autobusVM)
        {
            InitializeComponent();
            view = this;
            DataContext = new AEPutnikViewModel(function, autobusVM);
        }

        public AEPutnikView(bool function, Putnik selected, PutnikViewModel autobusVM)
        {
            InitializeComponent();
            view = this;
            DataContext = new AEPutnikViewModel(function, selected, autobusVM);
        }

    }
}
