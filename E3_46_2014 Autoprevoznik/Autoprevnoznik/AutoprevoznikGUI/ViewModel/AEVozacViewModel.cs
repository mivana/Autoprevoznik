using AutoprevoznikGUI.Model;
using AutoprevoznikGUI.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace AutoprevoznikGUI.ViewModel
{
    public class AEVozacViewModel
    {
        public AEVozacView view = null;
        public VozacViewModel vozacVM;

        private bool add = false;

        private ICommand addEditCommand { get; set; }
        private bool _canExecuteAddEdit;

        private ICommand cancelCommand { get; set; }
        private bool _canExecuteCancel;

        public Vozac selected;

        private List<Radnik> RadnikList { get; set; }
        private BindingList<string> RadnikBindingList { get; set; }


        public AEVozacViewModel(bool function, VozacViewModel vozacVM)
        {
            view = AEVozacView.view;
            this.vozacVM = vozacVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;

        }

        public AEVozacViewModel(bool function, Vozac selected, VozacViewModel vozacVM)
        {
            view = AEVozacView.view;
            this.vozacVM = vozacVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;
            this.selected = selected;

            view.br_doz.Text = selected.br_doz_voz.ToString();
            view.kategorije.Text = selected.kategorije.ToString();

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
            bool error = false;
            Model.Vozac novVozac = new Model.Vozac();
            Radnik radnik = new Radnik();
            int temp;

            view.errorDoz.Content = "";

            if (!Int32.TryParse(view.br_doz.Text, out temp) && view.br_doz.Text != "")
            {
                view.errorDoz.Content = "Unesite celobrojnu vrednost";
                error = true;
            }
            else
            {
                if (temp < 0)
                {
                    view.errorDoz.Content = "Unesite pozitivnu vrednost";
                    error = true;
                }
                else
                {
                    novVozac.br_doz_voz = temp;
                }
            }

            novVozac.kategorije = view.kategorije.Text;

            if (!error)
            {
                try
                {
                    if (!add)
                    {
                        using (var db = new AutoprevoznikDBEntities())
                        {
                            selected.br_doz_voz = novVozac.br_doz_voz;
                            selected.kategorije = novVozac.kategorije;
                            db.Entry(selected).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
                catch (Exception)
                {
                    view.errorDoz.Content = "Greska pri unosu entiteta u bazu";
                    return;
                }
                vozacVM.RefreshList();
                AEVozacView.view.Close();
            }

        }

        public void OnCancelCommand()
        {
            view.Close();
        }
    }
}