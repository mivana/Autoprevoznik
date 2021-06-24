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
    public class AENaseljeViewModel
    {
        public AENaseljeView view = null;
        public NaseljeViewModel naseljeVM;

        private bool add = false;

        private ICommand addEditCommand { get; set; }
        private bool _canExecuteAddEdit;

        private ICommand cancelCommand { get; set; }
        private bool _canExecuteCancel;

        public Naselje selected;

        public AENaseljeViewModel(bool function, NaseljeViewModel naseljeVM)
        {
            view = AENaseljeView.view;
            this.naseljeVM = naseljeVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;
        }

        public AENaseljeViewModel(bool function, Naselje selected, NaseljeViewModel naseljeVM)
        {
            view = AENaseljeView.view;
            this.naseljeVM = naseljeVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;
            view.tbImeNaselje.IsReadOnly = true;
            this.selected = selected;

            view.tbImeNaselje.Text = selected.ime_naselja;

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
            Model.Naselje newNaselje = new Model.Naselje();
            view.errorIme.Content = "";

            if (view.tbImeNaselje.Text == "")
            {
                view.errorIme.Content = "Popunite obavezno polje";
                error = true;
            }
            else
            {
                newNaselje.ime_naselja = view.tbImeNaselje.Text;
            }

            if (!error)
            {
                try
                {
                    if (add)
                    {
                        using (var db = new AutoprevoznikDBEntities())
                        {
                            List<Naselje> found = db.Naseljes.Where(a => a.ime_naselja.Equals(newNaselje.ime_naselja)).ToList();
                            if (found.Count() == 0)
                            {
                                db.Naseljes.Add(newNaselje);
                            }
                            else
                            {
                                view.errorIme.Content = "Ime vec postoji";
                                return;
                            }
                            db.SaveChanges();
                        }

                    }
                    else
                    {
                        using (var db = new AutoprevoznikDBEntities())
                        {
                            if (selected.ime_naselja.Equals(newNaselje.ime_naselja))
                            {
                                List<Naselje> found = db.Naseljes.Where(a => a.ime_naselja.Equals(newNaselje.ime_naselja)).ToList();
                                if (found.Count() == 0)
                                {
                                    db.Naseljes.Attach(selected);
                                    db.Naseljes.Remove(selected);
                                    db.Naseljes.Add(newNaselje);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    view.errorIme.Content = "Ime vec postoji";
                                    return;
                                }
                            }
                            else
                            {
                                db.Naseljes.Attach(selected);
                                db.Naseljes.Remove(selected);
                                db.Naseljes.Add(newNaselje);
                                db.SaveChanges();
                            }

                        }
                    }
                }
                catch (Exception)
                {
                    view.errorIme.Content = "Greska pri unosu entitita u bazu";
                    return;
                }
                AENaseljeView.view.Close();
                naseljeVM.RefreshList();
            }
        }
        public void OnCancelCommand()
        {
            view.Close();
        }
    }
}
