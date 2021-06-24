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
    public class AEGarazaViewModel
    {

        public AEGarazaView view = null;
        public GarazaViewModel garazaVM;

        private bool add = false;

        private ICommand addEditCommand { get; set; }
        private bool _canExecuteAddEdit;

        private ICommand cancelCommand { get; set; }
        private bool _canExecuteCancel;

        public Garaza selected;

        public List<Naselje> NaseljeList { get; set; }
        public BindingList<string> NaseljeBindingList { get; set; }

        public AEGarazaViewModel(bool function, GarazaViewModel garazaVM)
        {
            view = AEGarazaView.view;
            this.garazaVM = garazaVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;
            AddNaselje();
        }

        public AEGarazaViewModel(bool function, Garaza selected, GarazaViewModel garazaVM)
        {
            view = AEGarazaView.view;
            this.garazaVM = garazaVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;
            view.tbIdGaraze.IsReadOnly = true;
            this.selected = selected;

            view.tbIdGaraze.Text = selected.id_gar.ToString();
            view.CBImeNaselja.SelectedItem = selected.Naselje_ime_naselja;
            view.tbKapacitet.Text = selected.kapacitet.ToString();
            AddNaselje();
        }

        public void AddNaselje()
        {
            NaseljeList = new List<Naselje>();
            NaseljeBindingList = new BindingList<string>();

            using (var db = new AutoprevoznikDBEntities())
            {
                NaseljeList = db.Naseljes.ToList();
            }

            foreach (var Naselje in NaseljeList)
            {
                NaseljeBindingList.Add(Naselje.ime_naselja);
            }

            view.CBImeNaselja.ItemsSource = null;
            view.CBImeNaselja.ItemsSource = NaseljeBindingList;
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
            Model.Garaza newGaraza = new Model.Garaza();
            int temp;
            view.errorId.Content = "";
            view.errorKapacitet.Content = "";
            view.errorNaselje.Content = "";

            if (view.tbIdGaraze.Text == "")
            {
                view.errorId.Content = "Popunite obavezno polje";
                error = true;
            }
            if (!Int32.TryParse(view.tbIdGaraze.Text, out temp) && view.tbIdGaraze.Text != "")
            {
                view.errorId.Content = "Unesite celobrojnu vrednost";
                error = true;
            }
            else
            {
                if (temp < 0)
                {
                    view.errorId.Content = "Unesite pozitivnu vrednost";
                    error = true;
                }
                else
                {
                    newGaraza.id_gar = temp;
                }
                
            }

            if (view.CBImeNaselja.SelectedItem == null)
            {
                view.errorNaselje.Content = "Izaberi Naselje gde se nalazi";
                error = true;
            }
            else
            {
                newGaraza.Naselje_ime_naselja = view.CBImeNaselja.SelectedItem.ToString();
            }

            if (!Int32.TryParse(view.tbKapacitet.Text, out temp) && view.tbKapacitet.Text != "")
            {
                view.errorKapacitet.Content = "Unesite celobrojnu vrednost";
                error = true;
            }
            else
            {
                if (temp < 0)
                {
                    view.errorKapacitet.Content = "Unesite pozitivnu vrednost";
                    error = true;
                }
                else
                {
                    newGaraza.kapacitet = temp;
                }
            }

            if (!error)
            {
                if (add)
                {
                    try
                    {
                        using (var db = new AutoprevoznikDBEntities())
                        {
                            List<Garaza> found = db.Garazas.Where(a => a.id_gar == newGaraza.id_gar).ToList();
                            if (found.Count() == 0)
                            {
                                db.Garazas.Add(newGaraza);
                            }
                            else
                            {
                                view.errorId.Content = "Id vec postoji";
                                return;
                            }
                            db.SaveChanges();
                        }
                    }
                    catch(Exception)
                    {
                        view.errorId.Content = "Greska pri unosu entiteta u bazu";
                        return;
                    }
                }
                else
                {
                    try
                    {
                        using (var db = new AutoprevoznikDBEntities())
                        {
                            if (selected.id_gar != newGaraza.id_gar)
                            {
                                List<Garaza> found = db.Garazas.Where(a => a.id_gar == newGaraza.id_gar).ToList();
                                if (found.Count() == 0)
                                {
                                    db.Garazas.Attach(selected);
                                    db.Garazas.Remove(selected);
                                    db.Garazas.Add(newGaraza);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    view.errorId.Content = "Id vec postoji";
                                    return;
                                }
                            }
                            else
                            {
                                db.Garazas.Attach(selected);
                                db.Garazas.Remove(selected);
                                db.Garazas.Add(newGaraza);
                                db.SaveChanges();
                            }

                        }
                    }
                    catch (Exception)
                    {
                        view.errorId.Content = "Greska pri unosu entiteta u bazu";
                        return;
                    }
                }
                AEGarazaView.view.Close();
                garazaVM.RefreshList();
            }
        }
        public void OnCancelCommand()
        {
            view.Close();
        }
    }
}
