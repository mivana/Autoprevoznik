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
    public class AEPutujeViewModel
    {
        public AEPutujeView view = null;
        public PutujeViewModel putujeVM;

        private bool add = false;

        private ICommand addEditCommand { get; set; }
        private bool _canExecuteAddEdit;

        private ICommand cancelCommand { get; set; }
        private bool _canExecuteCancel;

        public Putuje selected;

        public BindingList<string> RegBindingList { get; set; }
        public List<Autobu> RegList { get; set; }

        public BindingList<string> LinijaBindingList { get; set; }
        public List<Linija> LinijaList { get; set; }


        public AEPutujeViewModel(bool function, PutujeViewModel putujeVM)
        {
            view = AEPutujeView.view;
            this.putujeVM = putujeVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;

            AddRegistracija();
            AddLinije();
        }

        public AEPutujeViewModel(bool function, Putuje selected, PutujeViewModel putujeVM)
        {
            view = AEPutujeView.view;
            this.putujeVM = putujeVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;
            this.selected = selected;

            AddRegistracija();
            AddLinije();

            view.CBReg.SelectedItem = selected.Autobus_reg.ToString();
            view.CBLinije.SelectedItem = selected.Linija_br_linije.ToString();
            string datePolaska = selected.dv_polaska.ToString();
            string dateDolaska = selected.dv_dolaska.ToString();
            view.tb_datumPolaska.SelectedDate = selected.dv_polaska;
            view.tb_datumDolaska.SelectedDate = selected.dv_dolaska;

            
            string timePolaskaToken = datePolaska.Split(' ')[1];
            if (datePolaska.Split(' ')[2] == "AM")
            {
                string[] tokens = timePolaskaToken.Split(':');
                view.tbSat.Text = tokens[0];
                view.tbMinut.Text = tokens[1];
            }
            if (datePolaska.Split(' ')[2] == "PM")
            {
                string[] tokens = timePolaskaToken.Split(':');
                view.tbSat.Text = (Int32.Parse(tokens[0]) + 12).ToString();
                view.tbMinut.Text = (Int32.Parse(tokens[1])).ToString();
            }

            if (selected.dv_dolaska != null)
            {
                string timeDolaskaToken = dateDolaska.Split(' ')[1];
                if (dateDolaska.Split(' ')[2] == "AM")
                {
                    string[] tokens = timeDolaskaToken.Split(':');
                    view.tbSatDolaska.Text = tokens[0];
                    view.tbMinutDolaska.Text = tokens[1];
                }
                if (dateDolaska.Split(' ')[2] == "PM")
                {
                    string[] tokens = timeDolaskaToken.Split(':');
                    view.tbSatDolaska.Text = (Int32.Parse(tokens[0]) + 12).ToString();
                    view.tbMinutDolaska.Text = (Int32.Parse(tokens[1])).ToString();
                }
            }

        }

        void AddRegistracija()
        {
            RegList = new List<Autobu>();
            RegBindingList = new BindingList<string>();

            using (var db = new AutoprevoznikDBEntities())
            {
                RegList = db.Autobus.ToList();
            }

            foreach (var autobus in RegList)
            {
                RegBindingList.Add(autobus.reg.ToString());
            }

            view.CBReg.ItemsSource = null;
            view.CBReg.ItemsSource = RegBindingList;
        }

        void AddLinije()
        {
            LinijaList = new List<Linija>();
            LinijaBindingList = new BindingList<string>();

            using (var db = new AutoprevoznikDBEntities())
            {
                LinijaList = db.Linijas.ToList();
            }

            foreach (var linija in LinijaList)
            {
                LinijaBindingList.Add(linija.br_linije.ToString());
            }

            view.CBLinije.ItemsSource = null;
            view.CBLinije.ItemsSource = LinijaBindingList;
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
            Model.Putuje newPutuje = new Model.Putuje();
            int temp;
            view.errorReg.Content = "";
            view.errorLinija.Content = "";
            view.errorDVPolaska.Content = "";

            if (view.CBReg.SelectedItem == null)
            {
                view.errorReg.Content = "Izaberi Registraciju autobusa";
                error = true;
            }
            else
            {
                newPutuje.Autobus_reg = Int32.Parse(view.CBReg.SelectedItem.ToString());
            }

            if (view.CBLinije.SelectedItem == null)
            {
                view.errorLinija.Content = "Izaberi Liniju";
                error = true;
            }
            else
            {
                newPutuje.Linija_br_linije = Int32.Parse(view.CBLinije.SelectedItem.ToString());
            }

            if (view.tb_datumPolaska.SelectedDate == null)
            {
                view.errorDVPolaska.Content = "Izaberi Datum polaska";
                error = true;
            }
            else
            {
                if (selected.dv_polaska == null)
                {
                    if (!Int32.TryParse(view.tbSat.Text, out temp) && view.tbSat.Text != "")
                    {
                        view.errorDVPolaska.Content = "Unesite celobrojnu vrednost za vreme polaska";
                        error = true;
                    }
                    if (view.tbSat.Text == "")
                    {
                        view.errorDVPolaska.Content = "Popunite vreme polaska";
                        error = true;
                    }
                    else
                    {
                        int sat = temp;
                        if (!Int32.TryParse(view.tbMinut.Text, out temp) && view.tbMinut.Text != "")
                        {
                            view.errorDVPolaska.Content = "Unesite celobrojnu vrednost za vreme polaska";
                            error = true;
                        }
                        if (view.tbMinut.Text == "")
                        {
                            view.errorDVPolaska.Content = "Popunite vreme polaska";
                            error = true;
                        }
                        else
                        {
                            int minut = temp;
                            if (minut < 0 || minut > 60)
                            {
                                view.errorDVPolaska.Content = "Unesite ne negativnu vrednost koja je manja od 60 za minut polaska";
                                error = true;
                            }
                            else
                            {
                                if (sat < 0 || sat > 24)
                                {
                                    view.errorDVPolaska.Content = "Unesite ne negativnu vrednost koja je manja od 24 za sat polaska";
                                    error = true;
                                }
                                else
                                {
                                    DateTime date = (DateTime)view.tb_datumPolaska.SelectedDate;
                                    var newdate = new DateTime(date.Year, date.Month, date.Day, sat, minut, 0);
                                    newPutuje.dv_polaska = newdate;

                                }
                            }
                        }
                    }
                }
                else
                {
                    newPutuje.dv_polaska = selected.dv_polaska;
                }
            }

            if (view.tb_datumDolaska.SelectedDate == null)
            {
                newPutuje.dv_dolaska = null;
            }
            else
            {
                if(newPutuje.dv_polaska > (DateTime)view.tb_datumDolaska.SelectedDate)
                {
                    view.errorDVDolaska.Content = "Datum dolaska ne moze biti datuma polaska";
                    error = true;
                }
                else
                if (!Int32.TryParse(view.tbSatDolaska.Text, out temp) && view.tbSatDolaska.Text != "")
                {
                    view.errorDVDolaska.Content = "Unesite celobrojnu vrednost za vreme polaska";
                    error = true;
                }
                else
                {
                    int sat = temp;
                    if (!Int32.TryParse(view.tbMinutDolaska.Text, out temp) && view.tbMinutDolaska.Text != "")
                    {
                        view.errorDVDolaska.Content = "Unesite celobrojnu vrednost za vreme polaska";
                        error = true;
                    }
                    else
                    {
                        int minut = temp;
                        if (minut < 0 || minut > 60)
                        {
                            view.errorDVDolaska.Content = "Unesite ne negativnu vrednost koja je manja od 60 za minut polaska";
                            error = true;
                        }
                        else
                        {
                            if (sat < 0 || sat > 24)
                            {
                                view.errorDVDolaska.Content = "Unesite ne negativnu vrednost koja je manja od 24 za sat polaska";
                                error = true;
                            }
                            else
                            {
                                DateTime date = (DateTime)view.tb_datumDolaska.SelectedDate;
                                var newdate = new DateTime(date.Year, date.Month, date.Day, sat, minut, 0);
                                newPutuje.dv_dolaska = newdate;

                            }
                        }
                    }
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
                            List<Putuje> found = db.Putujes.Where(a => a.Autobus_reg == newPutuje.Autobus_reg && a.Linija_br_linije == newPutuje.Linija_br_linije
                                                                        && a.dv_polaska == newPutuje.dv_polaska).ToList();
                            if (found.Count() == 0)
                            {
                                db.Putujes.Add(newPutuje);
                            }
                            else
                            {
                                view.errorReg.Content = "Vec postoji ovaj autobus da putuje u to vreme";
                                return;
                            }
                            db.SaveChanges();
                        }

                    }
                    else
                    {
                        using (var db = new AutoprevoznikDBEntities())
                        {
                            if (selected.Autobus_reg != newPutuje.Autobus_reg || selected.Linija_br_linije != newPutuje.Linija_br_linije
                                                                         || selected.dv_polaska != newPutuje.dv_polaska)
                            {
                                List<Putuje> found = db.Putujes.Where(a => a.Autobus_reg == newPutuje.Autobus_reg && a.Linija_br_linije == newPutuje.Linija_br_linije
                                                                         && a.dv_polaska == newPutuje.dv_polaska).ToList();
                                if (found.Count() == 0)
                                {
                                    db.Putujes.Attach(selected);
                                    db.Putujes.Remove(selected);
                                    db.Putujes.Add(newPutuje);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    view.errorReg.Content = "Vec postoji ovaj autobus da putuje u to vreme";
                                    return;
                                }
                            }
                            else
                            {
                                //db.Putujes.Attach(selected);
                                //db.Putujes.Remove(selected);
                                //db.Putujes.Add(newPutuje);
                                Putuje selected = db.Putujes.First(a => a.Autobus_reg == newPutuje.Autobus_reg && a.Linija_br_linije == newPutuje.Linija_br_linije && a.dv_polaska == newPutuje.dv_polaska);
                                selected.dv_dolaska = newPutuje.dv_dolaska;
                                db.Entry(selected).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }

                        }
                    }
                }
                catch (Exception)
                {
                    view.errorReg.Content = "Greska pri unosu entiteta u bazu";
                    return;
                }
                AEPutujeView.view.Close();
                putujeVM.RefreshList();
            }
        }

        public void OnCancelCommand()
        {
            view.Close();
        }
    }
}