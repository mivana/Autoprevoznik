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
    public class KartaViewModel
    {
        public bool _canExecute;

        public KartaView view = KartaView.view;

        public BindingList<Model.Karta> KartaBindingList { get; set; }
        public List<Model.Karta> KartaList { get; set; }

        public Karta selected { get; set; }

        public ICommand addCommand { get; set; }
        public ICommand editCommand { get; set; }
        public ICommand removeCommand { get; set; }
        public ICommand refreshCommand { get; set; }

        public KartaViewModel()
        {
            _canExecute = true;

            selected = new Karta();

            RefreshList();
        }

        public void RefreshList()
        {
            KartaList = new List<Karta>();

            using (var db = new AutoprevoznikDBEntities())
            {
                KartaList = db.Kartas.ToList();
            }

            KartaBindingList = new BindingList<Karta>(KartaList);

            view.dataGrid.ItemsSource = null;
            view.dataGrid.ItemsSource = KartaBindingList;
        }

        public ICommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new CommandHandler(() => OnAdd(), _canExecute));
            }
        }

        public void OnAdd()
        {
            AEKartaView newView = new AEKartaView(true, this);
            newView.ShowDialog();
        }

        public ICommand EditCommand
        {
            get
            {
                return editCommand ?? (editCommand = new CommandHandler(() => OnEdit(), _canExecute));
            }
        }

        public void OnEdit()
        {
            if (view.dataGrid.SelectedItem == null)
            {
                view.result.Text = "ERROR: Please first select what entity you want to edit";
            }
            else
            {
                selected = (Karta)view.dataGrid.SelectedItem;
                AEKartaView newView = new AEKartaView(false, selected, this);
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

                    selected = (Karta)view.dataGrid.SelectedItem;
                    using (var db = new AutoprevoznikDBEntities())
                    {
                        db.Entry(selected).State = System.Data.Entity.EntityState.Deleted; 
                        //db.Kartas.Attach(selected);
                        //db.Kartas.Remove(selected);
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
