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
    public class GarazaViewModel
    {
        public bool _canExecute;

        public GarazaView view = GarazaView.view;

        public BindingList<Model.Garaza> GarazaBindingList { get; set; }
        public List<Model.Garaza> GarazaList { get; set; }

        public Garaza selected { get; set; }

        public ICommand addCommand { get; set; }
        public ICommand editCommand { get; set; }
        public ICommand removeCommand { get; set; }
        public ICommand refreshCommand { get; set; }

        public GarazaViewModel()
        {
            _canExecute = true;

            selected = new Garaza();

            RefreshList();
        }

        public void RefreshList()
        {
            GarazaList = new List<Garaza>();

            using (var db = new AutoprevoznikDBEntities())
            {
                GarazaList = db.Garazas.ToList();
            }

            GarazaBindingList = new BindingList<Garaza>(GarazaList);

            view.dataGrid.ItemsSource = null;
            view.dataGrid.ItemsSource = GarazaBindingList;
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
            AEGarazaView newView = new AEGarazaView(true, this);
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
                selected = (Garaza)view.dataGrid.SelectedItem;
                AEGarazaView aea = new AEGarazaView(false, selected, this);
                aea.ShowDialog();
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

                    selected = (Garaza)view.dataGrid.SelectedItem;
                    using (var db = new AutoprevoznikDBEntities())
                    {
                        db.Entry(selected).State = System.Data.Entity.EntityState.Deleted;

                        //db.Garazas.Attach(selected);
                        //db.Garazas.Remove(selected);
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
