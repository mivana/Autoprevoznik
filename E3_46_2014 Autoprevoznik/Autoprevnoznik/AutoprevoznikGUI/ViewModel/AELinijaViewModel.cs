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
    public class AELinijaViewModel
    {

        public AELinijaView view = null;
        public LinijaViewModel LinijaVM;

        private bool add = false;

        private ICommand addEditCommand { get; set; }
        private bool _canExecuteAddEdit;

        private ICommand cancelCommand { get; set; }
        private bool _canExecuteCancel;

        public Linija selected;

        private List<Naselje> NaseljeList { get; set; }
        private BindingList<string> NaseljeBindingList { get; set; }

        public AELinijaViewModel(bool function, LinijaViewModel LinijaVM)
        {
            view = AELinijaView.view;
            this.LinijaVM = LinijaVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;
            AddNaselje();
        }

        public AELinijaViewModel(bool function, Linija selected, LinijaViewModel LinijaVM)
        {
            view = AELinijaView.view;
            this.LinijaVM = LinijaVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;
            view.tbBrLinije.IsReadOnly = true;
            this.selected = selected;
            AddNaselje();

            view.tbBrLinije.Text = selected.br_linije.ToString();
            view.tbImeLinije.Text = selected.ime_linije;

            using (var db = new AutoprevoznikDBEntities())
            {
                this.selected = db.Linijas.Where(a => a.br_linije == selected.br_linije).ToList()[0];
                foreach (var Naselje in this.selected.Naseljes)
                {
                    view.LBNaselje.SelectedItems.Add(Naselje.ime_naselja);
                }
            }

            
        }

        public void AddNaselje()
        {
            NaseljeList = new List<Naselje>();
            NaseljeBindingList = new BindingList<string>();

            using (var db = new AutoprevoznikDBEntities())
            {
                NaseljeList = db.Naseljes.ToList();
            }

            foreach(var Naselje in NaseljeList)
            {
                NaseljeBindingList.Add(Naselje.ime_naselja);
            }

            view.LBNaselje.ItemsSource = null;
            view.LBNaselje.ItemsSource = NaseljeBindingList;
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
            Model.Linija newLinija = new Model.Linija();
            int temp;
            view.errorBr.Content = "";
            view.errorNaselje.Content = "";

            if (view.tbBrLinije.Text == "")
            {
                view.errorBr.Content = "Popunite obavezno polje";
                error = true;
            }
            if (!Int32.TryParse(view.tbBrLinije.Text, out temp) && view.tbBrLinije.Text != "")
            {
                view.errorBr.Content = "Unesite celobrojnu vrednost";
                error = true;
            }
            else
            {
                if (temp < 0)
                {
                    view.errorBr.Content = "Unesite pozitivnu vrednost";
                    error = true;
                }
                else
                {
                    newLinija.br_linije = temp;
                }
            }

            newLinija.ime_linije = view.tbImeLinije.Text;
            List<Naselje> selectedNaselje = new List<Naselje>();

            if(view.LBNaselje.SelectedItems.Count == 0)
            {
                view.errorNaselje.Content = "Izaberite min 1 naselje";
                error = true;
            }
            else
            {
                foreach (var naselje in view.LBNaselje.SelectedItems)
                {
                    selectedNaselje.Add(NaseljeList.Find(a => a.ime_naselja == naselje.ToString()));
                }
            }


            if (!error)
            {
                try
                {
                    if (add)
                    {
                        using (var db = new AutoprevoznikDBEntities())
                        {

                            List<Linija> foundL = db.Linijas.Where(a => a.br_linije == newLinija.br_linije).ToList();
                            if (foundL.Count() == 0)
                            {
                                List<Naselje> found = new List<Naselje>();
                                 Naselje nn = new Naselje();
                                foreach (var n in selectedNaselje)
                                {
                                    nn = db.Naseljes.Find(n.ime_naselja);
                                    newLinija.Naseljes.Add(nn);
                                    nn.Linijas.Add(newLinija);
                                }
                                db.SaveChanges();
                            }
                            else
                            {
                                view.errorBr.Content = "Broj linije vec postoji";
                                return;
                            }

                        }
                    }
                    else
                    {
                        using (var db = new AutoprevoznikDBEntities())
                        {
                            Linija foundL = db.Linijas.Find(newLinija.br_linije);
                            if (foundL != null)
                            {
                                foundL.ime_linije = newLinija.ime_linije;

                                foreach(var naselje in db.Naseljes.ToList())
                                {
                                    List<Naselje> f = selectedNaselje.Where(i => i.ime_naselja == naselje.ime_naselja).ToList();
                                    
                                    if (f.Count() == 0)
                                    { 
                                        if (naselje.Linijas.Contains(foundL))
                                        {
                                            naselje.Linijas.Remove(foundL);
                                            db.Entry(naselje).State = System.Data.Entity.EntityState.Modified;
                                        }
                                    }
                                    else
                                    {
                                        if (!naselje.Linijas.Contains(foundL))
                                        {
                                            foundL.Naseljes.Add(naselje);
                                            naselje.Linijas.Add(foundL);
                                            db.Entry(naselje).State = System.Data.Entity.EntityState.Modified;
                                        }
                                    }

                                }

                                db.Entry(foundL).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }
                            else
                            {
                                view.errorBr.Content = "Broj linije vec postoji";
                                return;
                            }

                        }
                    }
                }
                catch(Exception e)
                {
                    view.errorBr.Content = "Greska pri unosu entiteta u bazu";
                    return;
                }
                AELinijaView.view.Close();
                LinijaVM.RefreshList();
            }
        }
        public void OnCancelCommand()
        {
            view.Close();
        }
    }
}
