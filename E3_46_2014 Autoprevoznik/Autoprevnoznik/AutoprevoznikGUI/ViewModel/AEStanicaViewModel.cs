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
    public class AEStanicaViewModel
    {

        public AEStanicaView view = null;
        public StanicaViewModel StanicaVM;

        private bool add = false;

        private ICommand addEditCommand { get; set; }
        private bool _canExecuteAddEdit;

        private ICommand cancelCommand { get; set; }
        private bool _canExecuteCancel;

        public Stanica selected;

        private List<Naselje> NaseljeList { get; set; }
        private BindingList<string> NaseljeBindingList { get; set; }

        public AEStanicaViewModel(bool function, StanicaViewModel StanicaVM)
        {
            view = AEStanicaView.view;
            this.StanicaVM = StanicaVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;
            AddNaselje();
        }

        public AEStanicaViewModel(bool function, Stanica selected, StanicaViewModel StanicaVM)
        {
            view = AEStanicaView.view;
            this.StanicaVM = StanicaVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;
            view.tbIdStanice.IsReadOnly = true;
            this.selected = selected;
            AddNaselje();

            view.tbIdStanice.Text = selected.id_st.ToString();
            view.CBImeNaselja.SelectedItem = selected.Naselje_ime_naselja.ToString();
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
            Model.Stanica newStanica = new Model.Stanica();
            int temp;
            view.errorId.Content = "";
            view.errorNaselje.Content = "";

            if (view.tbIdStanice.Text == "")
            {
                view.errorId.Content = "Popunite obavezno polje";
                error = true;
            }
            if (!Int32.TryParse(view.tbIdStanice.Text, out temp) && view.tbIdStanice.Text != "")
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
                    newStanica.id_st = temp;
                }
               
            }

            if (view.CBImeNaselja.SelectedItem == null)
            {
                view.errorNaselje.Content = "Izaberi Naselje gde se nalazi";
                error = true;
            }
            else
            {
                newStanica.Naselje_ime_naselja = view.CBImeNaselja.SelectedItem.ToString();
            }

            if (!error)
            {
                try
                {
                    if (add)
                    {
                        using (var db = new AutoprevoznikDBEntities())
                        {
                            List<Stanica> found = db.Stanicas.Where(a => a.id_st == newStanica.id_st).ToList();
                            if (found.Count() == 0)
                            {
                                db.Stanicas.Add(newStanica);
                            }
                            else
                            {
                                view.errorId.Content = "Id vec postoji";
                                return;
                            }
                            db.SaveChanges();
                        }

                    }
                    else
                    {
                        using (var db = new AutoprevoznikDBEntities())
                        {
                            if (selected.id_st != newStanica.id_st)
                            {
                                List<Stanica> found = db.Stanicas.Where(a => a.id_st == newStanica.id_st).ToList();
                                if (found.Count() == 0)
                                {
                                    db.Stanicas.Attach(selected);
                                    db.Stanicas.Remove(selected);
                                    db.Stanicas.Add(newStanica);
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
                                db.Stanicas.Attach(selected);
                                db.Stanicas.Remove(selected);
                                db.Stanicas.Add(newStanica);
                                db.SaveChanges();
                            }


                        }
                    }
                }
                catch (Exception)
                {
                    view.errorId.Content = "Greska pri unosu entiteta u bazu";
                    return;
                }
                AEStanicaView.view.Close();
                StanicaVM.RefreshList();
            }
        }
        public void OnCancelCommand()
        {
            view.Close();
        }
    }
}
