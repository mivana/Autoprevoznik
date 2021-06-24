using AutoprevoznikGUI.Model;
using AutoprevoznikGUI.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace AutoprevoznikGUI.ViewModel
{
    public class AEKartaViewModel
    {

        public AEKartaView view = null;
        public KartaViewModel kartaVM;

        private bool add = false;

        private ICommand addEditCommand { get; set; }
        private bool _canExecuteAddEdit;

        private ICommand cancelCommand { get; set; }
        private bool _canExecuteCancel;

        private ICommand infoPutnikCommand { get; set; }
        private bool _canExecuteInfoP;

        private ICommand infoRutaCommand { get; set; }
        private bool _canExecuteInfoR;

        public Karta selected;

        public List<Putnik> PutnikList { get; set; }
        public BindingList<string> PutnikBindingList { get; set; }

        public List<Putuje> PutujeList { get; set; }
        public BindingList<string> PutujeBindingList { get; set; }

        public AEKartaViewModel(bool function, KartaViewModel kartaVM)
        {
            view = AEKartaView.view;
            this.kartaVM = kartaVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;
            _canExecuteInfoP = true;
            _canExecuteInfoR = true;
            AddPutnik();
            AddRuta();
        }

        public AEKartaViewModel(bool function, Karta selected, KartaViewModel kartaVM)
        {
            view = AEKartaView.view;
            this.kartaVM = kartaVM;
            this.add = function;
            _canExecuteAddEdit = true;
            _canExecuteCancel = true;
            _canExecuteInfoP = true;
            _canExecuteInfoR = true;

            view.CBPutnik.IsReadOnly = true;
            view.CBRuta.IsReadOnly = true;
            this.selected = selected;
            AddPutnik();
            AddRuta();

            Putnik selectedItem = PutnikList.Find(a => a.mbr_p == selected.Putnik_mbr_p);
            view.CBPutnik.SelectedItem = String.Format("Mbr:{0},Ime:{1},Prz:{2}", selectedItem.mbr_p.ToString(), selectedItem.ime_p, selectedItem.prz_p);

            Putuje selectedPutuje = PutujeList.Find(a => a.Linija_br_linije == selected.Putuje_Linija_br_linije && a.Autobus_reg == selected.Putuje_Autobus_reg && a.dv_polaska == selected.Putuje_dv_polaska);
            view.CBRuta.SelectedItem = String.Format("Linija:{0},Reg:{1},Polazak:{2}", selectedPutuje.Linija_br_linije.ToString(), selectedPutuje.Autobus_reg.ToString(), selectedPutuje.dv_polaska);

            view.tbCena.Text = selected.cena.ToString();
            view.tbRelacija.Text = selected.relacija;
        }

        void AddPutnik()
        {
            PutnikList = new List<Putnik>();
            PutnikBindingList = new BindingList<string>();

            using (var db = new AutoprevoznikDBEntities())
            {
                PutnikList = db.Putniks.ToList();
            }

            foreach (var putnik in PutnikList)
            {
                PutnikBindingList.Add(String.Format("Mbr:{0},Ime:{1},Prz:{2}",putnik.mbr_p.ToString(),putnik.ime_p,putnik.prz_p));
            }

            view.CBPutnik.ItemsSource = null;
            view.CBPutnik.ItemsSource = PutnikBindingList;
        }

        void AddRuta()
        {
            PutujeList = new List<Putuje>();
            PutujeBindingList = new BindingList<string>();

            using (var db = new AutoprevoznikDBEntities())
            {
                PutujeList = db.Putujes.ToList();
            }

            foreach (var putuje in PutujeList)
            {
                PutujeBindingList.Add(String.Format("Linija:{0},Reg:{1},Polazak:{2}",putuje.Linija_br_linije.ToString(),putuje.Autobus_reg.ToString(),putuje.dv_polaska));
            }

            view.CBRuta.ItemsSource = null;
            view.CBRuta.ItemsSource = PutujeBindingList;
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

        public ICommand InfoPutnikCommand
        {
            get
            {
                return infoPutnikCommand ?? (infoPutnikCommand = new CommandHandler(() => OnInfoPutnik(), _canExecuteInfoP));
            }
        }

        public ICommand InfoRutaCommand
        {
            get
            {
                return infoRutaCommand ?? (infoRutaCommand = new CommandHandler(() => OnInfoRuta(), _canExecuteInfoR));
            }
        }


        private void OnAddEditKompanija()
        {
            bool error = false;
            Model.Karta newKarta = new Model.Karta();
            Decimal temp;
            view.errorPutnik.Content = "";
            view.errorRuta.Content = "";

            if (view.CBPutnik.SelectedItem != null)
            {
                string selected_putnik = view.CBPutnik.SelectedItem.ToString();
                string[] tokens = selected_putnik.Split(',');
                string[] tokensSingle = tokens[0].Split(':');
                string selected_mbr = tokensSingle[1];

                newKarta.Putnik_mbr_p = Int32.Parse(selected_mbr);
            }
            else
            {
                error = true;
                view.errorPutnik.Content = "Izaberite Putnika";
            }

            if (view.CBRuta.SelectedItem != null)
            {

                string selected_ruta = view.CBRuta.SelectedItem.ToString();
                string[] tokensRuta = selected_ruta.Split(',');
                string selected_br_linije = tokensRuta[0].Split(':')[1];
                string selected_reg = tokensRuta[1].Split(':')[1];

                string[] selected_temp = tokensRuta[2].Split(' ');
                string selected_dv_polazak = selected_temp[0].Split(':')[1] + ' ' + selected_temp[1] + ' ' + selected_temp[2];

                newKarta.Putuje_Linija_br_linije = Int32.Parse(selected_br_linije);
                newKarta.Putuje_Autobus_reg = Int32.Parse(selected_reg);
                newKarta.Putuje_dv_polaska = DateTime.Parse(selected_dv_polazak);
            }
            else
            {
                error = true;
                view.errorRuta.Content = "Izaberite Rutu i Vreme putovanja";
            }

            if (!Decimal.TryParse(view.tbCena.Text, out temp) && view.tbCena.Text != "")
            {
                error = true;
                view.errorCena.Content = "Unesite decimalnu vrednost";
            }
            else
            {
                if (temp < 0)
                {
                    view.errorCena.Content = "Unesite pozitivnu vrednost";
                    error = true;
                }
                else
                {
                    newKarta.cena = temp;
                }
             
            }

            newKarta.relacija = view.tbRelacija.Text;
            newKarta.datum_kup = DateTime.Now;


            if (!error)
            {
                try
                {
                    using (var db = new AutoprevoznikDBEntities())
                    {
                        SqlParameter paramReg = new SqlParameter("@reg", newKarta.Putuje_Autobus_reg);
                        paramReg.Direction = ParameterDirection.Input;
                        paramReg.DbType = DbType.Int32;

                        SqlParameter paramLinija = new SqlParameter("@br_linije", newKarta.Putuje_Linija_br_linije);
                        paramLinija.Direction = ParameterDirection.Input;
                        paramLinija.DbType = DbType.Int32;

                        SqlParameter paramDVPolaska = new SqlParameter("@dvPolaska", newKarta.Putuje_dv_polaska);
                        paramDVPolaska.Direction = ParameterDirection.Input;
                        paramDVPolaska.DbType = DbType.DateTime;

                        var data = db.Database.SqlQuery<int>(@"select dbo.GetSeat(@reg,@br_linije,@dvPolaska)", paramReg, paramLinija, paramDVPolaska);
                        var newresult = data.First();

                        newKarta.sediste = newresult;

                    }
                }
                catch(Exception)
                {
                    view.errorPutnik.Content="Greska pri unosu sedista u Kartu";
                    return;
                }

                if (add)
                {
                    try
                    {
                        using (var db = new AutoprevoznikDBEntities())
                        {
                            List<Karta> found = db.Kartas.Where(a => a.Putnik_mbr_p == newKarta.Putnik_mbr_p && a.Putuje_Autobus_reg == newKarta.Putuje_Autobus_reg
                                                                        && a.Putuje_dv_polaska == newKarta.Putuje_dv_polaska && a.Putuje_Linija_br_linije == a.Putuje_Linija_br_linije).ToList();
                            if (found.Count() == 0)
                            {
                                db.Kartas.Add(newKarta);
                            }
                            else
                            {
                                view.errorPutnik.Content = "Putnik za ovu kartu vec postoji";
                                return;
                            }
                            db.SaveChanges();
                        }
                    }
                    catch (Exception)
                    {
                        view.errorPutnik.Content = "Greska pri unosu entitita u bazu";
                        return;
                    }

                }
                else
                {
                    try
                    {
                        using (var db = new AutoprevoznikDBEntities())
                        {
                            if (selected.Putnik_mbr_p != newKarta.Putnik_mbr_p && selected.Putuje_Autobus_reg == newKarta.Putuje_Autobus_reg
                                && selected.Putuje_dv_polaska == newKarta.Putuje_dv_polaska && selected.Putuje_Linija_br_linije == newKarta.Putuje_Linija_br_linije)
                            {
                                List<Karta> found = db.Kartas.Where(a => a.Putnik_mbr_p == newKarta.Putnik_mbr_p && a.Putuje_Autobus_reg == newKarta.Putuje_Autobus_reg
                                                                          && a.Putuje_dv_polaska == newKarta.Putuje_dv_polaska && a.Putuje_Linija_br_linije == a.Putuje_Linija_br_linije).ToList();

                                if (found.Count() == 0)
                                {
                                    db.Kartas.Attach(selected);
                                    db.Kartas.Remove(selected);
                                    db.Kartas.Add(newKarta);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    view.errorPutnik.Content = "Putnik je vec kupio ovu kartu";
                                    return;
                                }
                            }
                            else
                            {
                                db.Kartas.Attach(selected);
                                db.Kartas.Remove(selected);
                                db.Kartas.Add(newKarta);
                                db.SaveChanges();
                            }

                        }
                    }
                    catch (Exception)
                    {
                        view.errorPutnik.Content = "Greska pri unosu entitita u bazu";
                        return;
                    }

                }
                kartaVM.RefreshList();
                view.Close();
            }
        }

        public void OnCancelCommand()
        {
            view.Close();
        }

        public void OnInfoPutnik()
        {
            if(view.CBPutnik.SelectedItem != null)
            {
                Putnik selectedPutnik = null;
                selectedPutnik = PutnikList.Find(a => a.mbr_p == Int32.Parse(view.CBPutnik.SelectedItem.ToString()));

            }
        }

        public void OnInfoRuta()
        {
            if (view.CBRuta.SelectedItem != null)
            {
                Putuje selectedPutuje = null;
                selectedPutuje = PutujeList.Find(a => a.Linija_br_linije == Int32.Parse(view.CBRuta.SelectedItem.ToString()));

            }
        }



    }
}
