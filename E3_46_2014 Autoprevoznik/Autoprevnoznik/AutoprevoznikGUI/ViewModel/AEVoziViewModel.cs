using AutoprevoznikGUI.Model;
using AutoprevoznikGUI.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoprevoznikGUI.ViewModel
{
    public class AEVoziViewModel
    {

        private ICommand addEditCommand { get; set; }
        private bool _canExecuteAddEdit;

        private ICommand cancelCommand { get; set; }
        private bool _canExecuteCancel;

        public List<Autobu> AutobusList { get; set; }
        public BindingList<string> AutobusBindingList { get; set; }

        VozacViewModel model;
        Vozac selected;
        AEVoziView view = null;

        public AEVoziViewModel(Vozac selected, VozacViewModel model)
        {
            view = AEVoziView.view;
            this.model = model;
            this.selected = selected;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;


            AddAutobus();
        }

        void AddAutobus()
        {
            AutobusList = new List<Autobu>();
            AutobusBindingList = new BindingList<string>();

            using (var db = new AutoprevoznikDBEntities())
            {
                AutobusList = db.Autobus.ToList();
            }

            foreach (var autobu in AutobusList)
            {
                AutobusBindingList.Add(autobu.reg.ToString());
            }

            view.CBAutobus.ItemsSource = null;
            view.CBAutobus.ItemsSource = AutobusBindingList;

        }

        public ICommand AddEditCommand
        {
            get
            {
                return addEditCommand ?? (addEditCommand = new CommandHandler(() => OnAddEditKompanija(), _canExecuteAddEdit));
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                return cancelCommand ?? (cancelCommand = new CommandHandler(() => OnCancelCommand(), _canExecuteCancel));
            }
        }

        private void OnAddEditKompanija()
        {
            Autobu a = new Autobu();
            bool error = false;
            view.errorAutobus.Content = "";

            if (view.CBAutobus.SelectedItem == null)
            {
                view.errorAutobus.Content = "Izaberi Naselje gde se nalazi";
                error = true;
            }
            else
            {
                a.reg = Int32.Parse(view.CBAutobus.SelectedItem.ToString());
            }

            if (!error)
            { 
                try
                {
                    using (var db = new AutoprevoznikDBEntities())
                    {
                        Autobu auto = db.Autobus.Find(a.reg);
                        Radnik v = db.Radniks.Find(selected.mbr_r);
                        v.Vozac.Autobus.Add(auto);
                        auto.Vozacs.Add(v.Vozac);

                        db.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    view.errorAutobus.Content = "Greska pri unosu entiteta u bazu";
                    return;
                }
                AEVoziView.view.Close();
                model.RefreshList();
            }
        }

        public void OnCancelCommand()
        {
            view.Close();
        }
    }
}