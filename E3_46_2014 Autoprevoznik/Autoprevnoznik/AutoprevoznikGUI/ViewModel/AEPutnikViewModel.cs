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
    public class AEPutnikViewModel
    {

        public AEPutnikView view = null;
        public PutnikViewModel putnikVM;

        private bool add = false;

        private ICommand addEditCommand { get; set; }
        private bool _canExecuteAddEdit;

        private ICommand cancelCommand { get; set; }
        private bool _canExecuteCancel;

        public Putnik selected;

        public AEPutnikViewModel(bool function, PutnikViewModel putnikVM)
        {
            view = AEPutnikView.view;
            this.putnikVM = putnikVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;
        }

        public AEPutnikViewModel(bool function, Putnik selected, PutnikViewModel putnikVM)
        {
            view = AEPutnikView.view;
            this.putnikVM = putnikVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;
            view.tbMBR.IsReadOnly = true;

            this.selected = selected;

            view.tbMBR.Text = selected.mbr_p.ToString();
            view.tbIme.Text = selected.ime_p;
            view.tbPrezime.Text = selected.prz_p;
        }

        public ICommand AddEditCommand
        {
            get
            {
                return addEditCommand ?? (addEditCommand = new CommandHandler(() => OnAddEdit(), _canExecuteAddEdit));
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                return cancelCommand ?? (cancelCommand = new CommandHandler(() => OnCancel(), _canExecuteCancel));
            }
        }

        private void OnAddEdit()
        {
            bool error = false;
            Model.Putnik newPutnik = new Model.Putnik();
            int temp;
            view.errorMbr.Content = "";


            if (view.tbMBR.Text == "")
            {
                view.errorMbr.Content = "Popunite obavezno polje";
                error = true;
            }
            if (!Int32.TryParse(view.tbMBR.Text, out temp) && view.tbMBR.Text != "")
            {
                view.errorMbr.Content = "Unesite celobrojnu vrednost";
                error = true;
            }
            else
            {
                if (temp < 0)
                {
                    view.errorMbr.Content = "Unesite pozitivnu vrednost";
                    error = true;
                }
                else
                {
                    newPutnik.mbr_p = temp;
                }
            }

            newPutnik.ime_p = view.tbIme.Text;
            newPutnik.prz_p = view.tbPrezime.Text;

            if (!error)
            {
                try
                {
                    if (add)
                    {
                        using (var db = new AutoprevoznikDBEntities())
                        {

                            List<Putnik> found = db.Putniks.Where(a => a.mbr_p == newPutnik.mbr_p).ToList();
                            if (found.Count() == 0)
                            {
                                db.Putniks.Add(newPutnik);
                            }
                            else
                            {
                                view.errorMbr.Content = "Mbr vec postoji";
                                return;
                            }
                            db.SaveChanges();
                        }

                    }
                    else
                    {
                        using (var db = new AutoprevoznikDBEntities())
                        {
                            if (selected.mbr_p != newPutnik.mbr_p)
                            {
                                List<Putnik> found = db.Putniks.Where(a => a.mbr_p == newPutnik.mbr_p).ToList();
                                if (found.Count() == 0)
                                {
                                    db.Putniks.Attach(selected);
                                    db.Putniks.Remove(selected);
                                    db.Putniks.Add(newPutnik);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    view.errorMbr.Content = "Mbr vec postoji";
                                    return;
                                }
                            }
                            else
                            {
                                db.Putniks.Attach(selected);
                                db.Putniks.Remove(selected);
                                db.Putniks.Add(newPutnik);
                                db.SaveChanges();
                            }


                        }
                    }
                }
                catch (Exception)
                {
                    view.errorMbr.Content = "Greska pri unosu entiteta u bazu";
                    return;
                }
                putnikVM.RefreshList();
                AEPutnikView.view.Close();

            }

        }
        public void OnCancel()
        {
            view.Close();
        }
    }
}
