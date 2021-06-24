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
    public class KontrolerViewModel
    {
        public bool _canExecute;

        public KontrolerView view = KontrolerView.view;

        public BindingList<Model.Kontroler> KontrolerBindingList { get; set; }
        public List<Model.Kontroler> KontrolerList { get; set; }

        public Kontroler selected { get; set; }

        public ICommand proveraCommand { get; set; }
        public ICommand editCommand { get; set; }
        public ICommand removeCommand { get; set; }
        public ICommand refreshCommand { get; set; }


        public KontrolerViewModel()
        {
            _canExecute = true;

            selected = new Kontroler();

            RefreshList();
        }

        public void RefreshList()
        {
            KontrolerList = new List<Kontroler>();

            using (var db = new AutoprevoznikDBEntities())
            {
                KontrolerList = db.Kontrolers.ToList();
            }

            KontrolerBindingList = new BindingList<Kontroler>(KontrolerList);

            view.dataGrid.ItemsSource = null;
            view.dataGrid.ItemsSource = KontrolerBindingList;
        }

        public ICommand ProveravaCommand
        {
            get
            {
                return proveraCommand ?? (proveraCommand = new CommandHandler(() => OnProverava(), _canExecute));
            }
        }

        public void OnProverava()
        {
            if (view.dataGrid.SelectedItem == null)
            {
                view.result.Text = "ERROR: Please first select what entity you want to check";
            }
            else
            {
                selected = (Kontroler)view.dataGrid.SelectedItem;
                KontrolerProveravaView newView = new KontrolerProveravaView(selected, this);
                newView.ShowDialog();
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return removeCommand ?? (removeCommand = new CommandHandler(() => OnRemove(), _canExecute));
            }
        }

        public void OnRemove()
        {
            if (view.dataGrid.SelectedItem == null)
            {
                view.result.Text = "ERROR: Please first select what entity you want to delete";
            }
            else
            {
                try
                {
                    selected = (Kontroler)view.dataGrid.SelectedItem;
                    using (var db = new AutoprevoznikDBEntities())
                    {
                        db.Entry(selected).State = System.Data.Entity.EntityState.Deleted;

                        Radnik radnik = db.Radniks.Where(r => r.mbr_r == selected.mbr_r).First();
                        db.Entry(radnik).State = System.Data.Entity.EntityState.Deleted;

                        db.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    view.result.Text = "ERROR: Can not delete selected entity";
                }

               
                RefreshList();
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
