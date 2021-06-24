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
    public class TabeleViewModel
    {
        public List<TabeleVKKEntity> VoziLista { get; set; }
        public BindingList<TabeleVKKEntity> VoziBindingLista { get; set; }

        public List<TabeleVKKEntity> ProdajeLista { get; set; }
        public BindingList<TabeleVKKEntity> ProdajeBindingLista { get; set; }

        public List<TabeleVKKEntity> ProveravaLista { get; set; }
        public BindingList<TabeleVKKEntity> ProveravaBindingLista { get; set; }


        public ICommand refreshCommand { get; set; }
        public bool _canExecute;

        public TabeleView view;

        public TabeleViewModel()
        {
            view = TabeleView.view;
            _canExecute = true;
            RefreshList();
        }

        void RefreshList()
        {
            VoziLista = new List<TabeleVKKEntity>();
            ProdajeLista = new List<TabeleVKKEntity>();
            ProveravaLista = new List<TabeleVKKEntity>();
            using (var db = new AutoprevoznikDBEntities())
            {

                foreach(var auto in db.Autobus.ToList())
                {
                    foreach(var voz in auto.Vozacs)
                    {
                        VoziLista.Add(new TabeleVKKEntity() { Mbr = voz.mbr_r, Id = auto.reg });
                    }
                }
                VoziBindingLista = new BindingList<TabeleVKKEntity>(VoziLista);
                view.dataGridVozi.ItemsSource = VoziBindingLista;

                foreach (var karta in db.Kartas.ToList())
                {
                    foreach (var kond in karta.Kondukters)
                    {
                        ProdajeLista.Add(new TabeleVKKEntity() { Mbr = kond.mbr_r, Id = karta.Putuje_Autobus_reg,Karta = karta.Putnik_mbr_p,Linija = karta.Putuje_Linija_br_linije, Polazak = karta.Putuje_dv_polaska});
                    }

                    foreach (var kont in karta.Kontrolers)
                    {
                        ProveravaLista.Add(new TabeleVKKEntity() { Mbr = kont.mbr_r, Id = karta.Putuje_Autobus_reg, Karta = karta.Putnik_mbr_p, Linija = karta.Putuje_Linija_br_linije, Polazak = karta.Putuje_dv_polaska });
                    }
                }
                ProdajeBindingLista = new BindingList<TabeleVKKEntity>(ProdajeLista);
                view.dataGridProdaje.ItemsSource = ProdajeBindingLista;

                ProveravaBindingLista = new BindingList<TabeleVKKEntity>(ProveravaLista);
                view.dataGridProverava.ItemsSource = ProveravaBindingLista;


            }

        }

        public ICommand RefreshCommand
        {
            get
            {
                return refreshCommand ?? (refreshCommand = new CommandHandler(() => OnRefresh(), _canExecute));
            }
        }

        public void OnRefresh()
        {
            RefreshList();
        }



    }
}
