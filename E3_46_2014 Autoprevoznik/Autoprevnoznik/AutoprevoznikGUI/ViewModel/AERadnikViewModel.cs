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
    public class AERadnikViewModel
    {

        public AERadnikView view = null;
        public RadnikViewModel radnikVM;

        private bool add = false;

        private ICommand addEditCommand { get; set; }
        private bool _canExecuteAddEdit;

        private ICommand vozacCommand { get; set; }
        private bool _canExecuteVozac;

        private ICommand kondukterCommand { get; set; }
        private bool _canExecuteKondukter;

        private ICommand kontrolerCommand { get; set; }
        private bool _canExecuteKontroler;

        private ICommand cancelCommand { get; set; }
        private bool _canExecuteCancel;

        public Radnik selected;

        public AERadnikViewModel(bool function, RadnikViewModel radnikVM)
        {
            view = AERadnikView.view;
            this.radnikVM = radnikVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;
            _canExecuteVozac = true;
            _canExecuteKondukter = true;
            _canExecuteKontroler = true;

        }

        public AERadnikViewModel(bool function, Radnik selected, RadnikViewModel radnikVM)
        {
            view = AERadnikView.view;
            this.radnikVM = radnikVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;
            view.tb_mbr_r.IsReadOnly = true;

            this.selected = selected;

            view.tb_mbr_r.Text = selected.mbr_r.ToString();
            view.tb_ime_r.Text = selected.ime_r;
            view.tb_prz_r.Text = selected.prz_r;
            view.tb_adresa.Text = selected.adresa;
            view.tb_br_tel.Text = selected.br_tel.ToString();
            view.ugovor_skloljen.SelectedDate = selected.ugovor_sklopljen;
            view.ugovor_istekao.SelectedDate = selected.ugovor_istekao;
            view.tb_god_r.SelectedDate = selected.god_r;

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

        public ICommand VozacCommand
        {
            get
            {
                return vozacCommand ?? (vozacCommand = new CommandHandler(() => OnVozacCommand(), _canExecuteVozac));
            }
        }

        public ICommand KondukterCommand
        {
            get
            {
                return kondukterCommand ?? (kondukterCommand = new CommandHandler(() => OnKondukterCommand(), _canExecuteKondukter));
            }
        }

        public ICommand KontrolerCommand
        {
            get
            {
                return kontrolerCommand ?? (kontrolerCommand = new CommandHandler(() => OnKontrolerCommand(), _canExecuteKontroler));
            }
        }


        private void OnAddEditKompanija()
        {
            bool error = false;
            Model.Radnik newRadnik = new Model.Radnik();
            Vozac vozac = new Vozac();
            Kondukter kondukter = new Kondukter();
            Kontroler kontroler = new Kontroler();
            int temp;
            bool addVozac = false;
            bool addKond = false;
            bool addKont = false;

            view.errorMBR.Content = "";
            view.errorTel.Content = "";
            view.errorDatum.Content = "";
            view.errorUloga.Content = "";

            if (view.tb_mbr_r.Text == "")
            {
                view.errorMBR.Content = "Popunite obavezno polje";
                error = true;
            }
            else
            if (!Int32.TryParse(view.tb_mbr_r.Text, out temp) && view.tb_mbr_r.Text != "")
            {
                view.errorMBR.Content = "Unesite celobrojnu vrednost";
                error = true;
            }
            else
            {
                if (temp < 0)
                {
                    view.errorMBR.Content = "Unesite pozitivnu vrednost";
                    error = true;
                }
                else
                {
                    newRadnik.mbr_r = temp;

                }
            }

            newRadnik.ime_r = view.tb_ime_r.Text;
            newRadnik.prz_r = view.tb_prz_r.Text;
            newRadnik.adresa = view.tb_adresa.Text;

            if (!Int32.TryParse(view.tb_br_tel.Text, out temp) && view.tb_br_tel.Text != "")
            {
                view.errorTel.Content = "Unesite celobrojnu vrednost";
                error = true;
            }
            else
            {
                newRadnik.br_tel = temp;
            }

            if (view.ugovor_skloljen.SelectedDate == null)
            {
                view.errorDatum.Content = "Popunite datum";
            }
            else
            {
                newRadnik.ugovor_sklopljen = (DateTime)view.ugovor_skloljen.SelectedDate;
            }

            if (view.tb_god_r.SelectedDate == null)
            {
                newRadnik.god_r = null;
            }
            else
            {
                newRadnik.god_r = (DateTime)view.tb_god_r.SelectedDate;
            }

            if (view.ugovor_istekao.SelectedDate == null)
            {
                newRadnik.ugovor_istekao = null;
            }
            else
            {
                if (newRadnik.ugovor_sklopljen > (DateTime)view.ugovor_istekao.SelectedDate)
                {
                    view.errorDatum.Content = "Ugovor istekao ne moze biti posle ugovora sklopljen!";
                    error = true;
                }
                else
                {
                    newRadnik.ugovor_istekao = (DateTime)view.ugovor_istekao.SelectedDate;
                }
            }

            if (add && !(view.GridVozac.Visibility == System.Windows.Visibility.Visible || view.GridKondukter.Visibility == System.Windows.Visibility.Visible || view.GridKontroler.Visibility == System.Windows.Visibility.Visible))
            {
                view.errorUloga.Content = "Izaberite jednu ulogu radnika";
                error = true;
            }

            if (view.GridVozac.Visibility == System.Windows.Visibility.Visible)
            {
                if (!Int32.TryParse(view.tbBrDozVozac.Text, out temp) && view.tbBrDozVozac.Text != "")
                {
                    view.errorDozVozac.Content = "Unesite celobrojnu vrednost";
                    error = true;
                }
                else
                {
                    vozac.br_doz_voz = temp;
                }

                vozac.mbr_r = newRadnik.mbr_r;
                vozac.kategorije = view.tbKategorije.Text;

                newRadnik.Vozac = vozac;
                addVozac = true;
            }

            if (view.GridKondukter.Visibility == System.Windows.Visibility.Visible)
            {
                if (!Int32.TryParse(view.tbBrDozKond.Text, out temp) && view.tbBrDozKond.Text != "")
                {
                    view.errorDozKond.Content = "Unesite celobrojnu vrednost";
                    error = true;
                }
                else
                {
                    kondukter.br_doz_kond = temp;
                }

                kondukter.mbr_r = newRadnik.mbr_r;

                newRadnik.Kondukter = kondukter;
                addKond = true;
            }

            if (view.GridKontroler.Visibility == System.Windows.Visibility.Visible)
            {
                if (!Int32.TryParse(view.tbBrDozKont.Text, out temp) && view.tbBrDozKont.Text != "")
                {
                    view.errorDozKont.Content = "Unesite celobrojnu vrednost";
                    error = true;
                }
                else
                {
                    kontroler.br_doz_kont = temp;
                }

                kontroler.mbr_r = newRadnik.mbr_r;
                newRadnik.Kontroler = kontroler;
                addKont = true;
            }

            if (!error)
            {
                try
                {
                    if (add)
                    {
                        using (var db = new AutoprevoznikDBEntities())
                        {
                            List<Radnik> found = db.Radniks.Where(a => a.mbr_r == newRadnik.mbr_r).ToList();
                            if (found.Count() == 0)
                            {

                                db.Radniks.Add(newRadnik);
                                if (addVozac)
                                    db.Vozacs.Add(vozac);
                                if (addKond)
                                    db.Kondukters.Add(kondukter);
                                if (addKont)
                                    db.Kontrolers.Add(kontroler);
                                db.SaveChanges();
                            }
                            else
                            {
                                view.errorMBR.Content = "Mbr vec postoji";
                                return;
                            }

                        }

                    }
                    else
                    {
                        using (var db = new AutoprevoznikDBEntities())
                        {
                            selected.ime_r = newRadnik.ime_r;
                            selected.prz_r = newRadnik.prz_r;
                            selected.adresa = newRadnik.adresa;
                            selected.br_tel = newRadnik.br_tel;
                            selected.god_r = newRadnik.god_r;
                            selected.ugovor_sklopljen = newRadnik.ugovor_sklopljen;
                            selected.ugovor_istekao = newRadnik.ugovor_istekao;

                            db.Entry(selected).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
                catch (Exception)
                {
                    view.errorMBR.Content = "Greska pri unosu entiteta u bazu";
                    return;
                }
                AERadnikView.view.Close();
                radnikVM.RefreshList();
            }
        }
        public void OnCancelCommand()
        {
            view.Close();
        }

        public void OnVozacCommand()
        {
            view.GridVozac.Visibility = System.Windows.Visibility.Visible;
            view.GridKondukter.Visibility = System.Windows.Visibility.Collapsed;
            view.GridKontroler.Visibility = System.Windows.Visibility.Collapsed;

            view.UlogaVozac.Background = Brushes.AliceBlue;
            view.UlogaKondukter.Background = Brushes.LightGray;
            view.UlogaKontroler.Background = Brushes.LightGray;

            view.tbBrDozVozac.Text = "";
            view.tbKategorije.Text = "";
            view.tbBrDozKond.Text = "";
            view.tbBrDozKont.Text = "";
            view.errorDozVozac.Content = "";
            view.errorDozKond.Content = "";
            view.errorDozKont.Content = "";
            view.errorUloga.Content = "";
        }

        public void OnKondukterCommand()
        {
            view.GridVozac.Visibility = System.Windows.Visibility.Collapsed;
            view.GridKondukter.Visibility = System.Windows.Visibility.Visible;
            view.GridKontroler.Visibility = System.Windows.Visibility.Collapsed;

            view.UlogaVozac.Background = Brushes.LightGray;
            view.UlogaKondukter.Background = Brushes.AliceBlue;
            view.UlogaKontroler.Background = Brushes.LightGray;

            view.tbBrDozVozac.Text = "";
            view.tbKategorije.Text = "";
            view.tbBrDozKond.Text = "";
            view.tbBrDozKont.Text = "";
            view.errorDozVozac.Content = "";
            view.errorDozKond.Content = "";
            view.errorDozKont.Content = "";
            view.errorUloga.Content = "";
        }

        public void OnKontrolerCommand()
        {
            view.GridVozac.Visibility = System.Windows.Visibility.Collapsed;
            view.GridKondukter.Visibility = System.Windows.Visibility.Collapsed;
            view.GridKontroler.Visibility = System.Windows.Visibility.Visible;

            view.UlogaVozac.Background = Brushes.LightGray;
            view.UlogaKondukter.Background = Brushes.LightGray;
            view.UlogaKontroler.Background = Brushes.AliceBlue;

            view.tbBrDozVozac.Text = "";
            view.tbKategorije.Text = "";
            view.tbBrDozKond.Text = "";
            view.tbBrDozKont.Text = "";
            view.errorDozVozac.Content = "";
            view.errorDozKond.Content = "";
            view.errorDozKont.Content = "";
            view.errorUloga.Content = "";
        }

    }
}
