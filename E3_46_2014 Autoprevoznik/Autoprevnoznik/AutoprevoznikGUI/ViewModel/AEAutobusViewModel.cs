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
    public class AEAutobusViewModel
    {
        public AEAutobusView view = null;
        public AutobusViewModel autobusVM;

        private bool add = false;

        private ICommand addEditCommand { get; set; }
        private bool _canExecuteAddEdit;

        private ICommand cancelCommand { get; set; }
        private bool _canExecuteCancel;

        public Autobu selected;

        public AEAutobusViewModel(bool function, AutobusViewModel autobusVM)
        {
            view = AEAutobusView.view;
            this.autobusVM = autobusVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;

        }

        public AEAutobusViewModel(bool function, Autobu selected, AutobusViewModel autobusVM)
        {
            view = AEAutobusView.view;
            this.autobusVM = autobusVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;
            view.tbRegistracija.IsReadOnly = true;

            this.selected = selected;

            view.tbRegistracija.Text = selected.reg.ToString();
            view.tbModel.Text = selected.model;
            view.tbBrojMesta.Text = selected.br_mesta.ToString();
            view.datum_reg.SelectedDate = selected.dat_reg;

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
            Model.Autobu novAutobus = new Model.Autobu();
            int temp;
            view.errorReg.Content = "";
            view.errorBrMesta.Content = "";

            if (view.tbRegistracija.Text == "")
            {
                view.errorReg.Content = "Popunite obavezno polje";
                error = true;
            }
            if (!Int32.TryParse(view.tbRegistracija.Text, out temp) && view.tbRegistracija.Text != "")
            {
                view.errorReg.Content = "Unesite celobrojnu vrednost";
                error = true;
            }
            else
            {
                if(temp < 0)
                {
                    view.errorReg.Content = "Unesite pozitivnu vrednost";
                    error = true;
                }
                else
                {
                    novAutobus.reg = temp;
                }
            }

            novAutobus.model = view.tbModel.Text;
            if (!Int32.TryParse(view.tbBrojMesta.Text, out temp) && view.tbBrojMesta.Text != "")
            {
                view.errorBrMesta.Content = "Unesite celobrojnu vrednost";
                error = true;
            }
            else
            {

                if (temp < 0)
                {
                    view.errorBrMesta.Content = "Unesite pozitivnu vrednost";
                    error = true;
                }
                else
                {
                    novAutobus.br_mesta = temp;
                }
                
            }

            novAutobus.dat_reg = view.datum_reg.SelectedDate;

            if (!error)
            {
                if (add)
                {
                    try
                    {
                        using (var db = new AutoprevoznikDBEntities())
                        {
                            List<Autobu> found = db.Autobus.Where(a => a.reg == novAutobus.reg).ToList();
                            if (found.Count() == 0)
                            {
                                db.Autobus.Add(novAutobus);
                            }
                            else
                            {
                                view.errorReg.Content = "Registracija vec postoji";
                                return;
                            }
                            db.SaveChanges();

                        }
                    }
                    catch (Exception)
                    {
                        view.errorReg.Content = "Greska pri unosu Autobusa u bazu";
                        return;
                    }
                }
                else
                {
                    try
                    {

                        using (var db = new AutoprevoznikDBEntities())
                        {
                            if (selected.reg != novAutobus.reg)
                            {
                                List<Autobu> found = db.Autobus.Where(a => a.reg == novAutobus.reg).ToList();
                                if (found.Count() == 0)
                                {
                                    Autobu sel = db.Autobus.First(a => a.reg == selected.reg);
                                    sel.reg = novAutobus.reg;
                                    sel.model = novAutobus.model;
                                    sel.dat_reg = novAutobus.dat_reg;
                                    sel.br_mesta = novAutobus.br_mesta;
                                    db.Entry(sel).State = System.Data.Entity.EntityState.Modified;
                                    db.SaveChanges();
                                }
                                else
                                {
                                    view.errorReg.Content = "Registracija vec postoji";
                                    return;
                                }
                            }
                            else
                            {
                                Autobu sel = db.Autobus.First(a => a.reg == novAutobus.reg);
                                sel.reg = novAutobus.reg;
                                sel.model = novAutobus.model;
                                sel.dat_reg = novAutobus.dat_reg;
                                sel.br_mesta = novAutobus.br_mesta;
                                db.Entry(sel).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        view.errorReg.Content = "Greska pri unosu Autobusa u bazu";
                        return;
                    }
                }
                autobusVM.RefreshList();
                AEAutobusView.view.Close();
            }
        }
            
        public void OnCancelCommand()
        {
            view.Close();
        }
    }
}
