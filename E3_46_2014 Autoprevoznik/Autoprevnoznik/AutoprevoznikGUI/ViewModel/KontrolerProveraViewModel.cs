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
    public class KontrolerProveraViewModel
    {

        private ICommand addEditCommand { get; set; }
        private bool _canExecuteAddEdit;

        private ICommand cancelCommand { get; set; }
        private bool _canExecuteCancel;

        public List<Karta> KartaList { get; set; }
        public BindingList<string> KartaBindingList { get; set; }

        KontrolerViewModel model;
        Kontroler selected;
        KontrolerProveravaView view = null;

        public KontrolerProveraViewModel(Kontroler selected, KontrolerViewModel model)
        {
            view = KontrolerProveravaView.view;
            this.model = model;
            this.selected = selected;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;


            AddKarte();
        }

        void AddKarte()
        {
            KartaList = new List<Karta>();
            KartaBindingList = new BindingList<string>();

            using (var db = new AutoprevoznikDBEntities())
            {
                KartaList = db.Kartas.ToList();
            }

            foreach (var karta in KartaList)
            {
                KartaBindingList.Add(String.Format("Putnik:{0}, Linija:{1}, Reg:{2}, Polazak={3}, Kupljeno:{4}", karta.Putnik_mbr_p, karta.Putuje_Linija_br_linije, karta.Putuje_Autobus_reg, karta.Putuje_dv_polaska, karta.datum_kup));
            }

            view.CBKarta.ItemsSource = null;
            view.CBKarta.ItemsSource = KartaBindingList;

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
            Karta karta = new Karta();
            bool error = false;
            view.errorKarta.Content = "";

            if (view.CBKarta.SelectedItem == null)
            {
                view.errorKarta.Content = "Izaberi Karta";
                error = true;
            }
            else
            {
                string[] tokens = view.CBKarta.SelectedItem.ToString().Split(',');
                karta.Putnik_mbr_p = Int32.Parse(tokens[0].Split(':')[1]);
                karta.Putuje_Linija_br_linije = Int32.Parse(tokens[1].Split(':')[1]);
                karta.Putuje_Autobus_reg = Int32.Parse(tokens[2].Split(':')[1]);
                karta.Putuje_dv_polaska = DateTime.Parse(tokens[3].Split('=')[1]);
            }

            if (!error)
            {
                try
                {
                    using (var db = new AutoprevoznikDBEntities())
                    {
                        Karta found = db.Kartas.Find(karta.Putnik_mbr_p, karta.Putuje_Autobus_reg, karta.Putuje_Linija_br_linije, karta.Putuje_dv_polaska);
                        Radnik v = db.Radniks.Find(selected.mbr_r);
                        v.Kontroler.Kartas.Add(found);
                        found.Kontrolers.Add(v.Kontroler);

                        db.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    view.errorKarta.Content = "Greska pri unosu entiteta u bazu";
                    return;
                }
                KontrolerProveravaView.view.Close();
                model.RefreshList();
            }
        }

        public void OnCancelCommand()
        {
            view.Close();
        }
    }
}