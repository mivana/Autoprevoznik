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
    public class StanicaViewModel
    {

        public bool _canExecute;

        public StanicaView view = StanicaView.view;

        public BindingList<Model.Stanica> StanicaBindingList { get; set; }
        public List<Model.Stanica> StanicaList { get; set; }

        public Stanica selected { get; set; }

        public ICommand addCommand { get; set; }
        public ICommand editCommand { get; set; }
        public ICommand removeCommand { get; set; }
        public ICommand refreshCommand { get; set; }

        public StanicaViewModel()
        {
            _canExecute = true;

            selected = new Stanica();

            RefreshList();
        }

        public void RefreshList()
        {
            StanicaList = new List<Stanica>();

            using (var db = new AutoprevoznikDBEntities())
            {
                StanicaList = db.Stanicas.ToList();
            }

            StanicaBindingList = new BindingList<Stanica>(StanicaList);

            view.dataGrid.ItemsSource = null;
            view.dataGrid.ItemsSource = StanicaBindingList;
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
            AEStanicaView newView = new AEStanicaView(true, this);
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
                selected = (Stanica)view.dataGrid.SelectedItem;
                AEStanicaView aea = new AEStanicaView(false, selected, this);
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
                    selected = (Stanica)view.dataGrid.SelectedItem;
                    using (var db = new AutoprevoznikDBEntities())
                    {
                        db.Entry(selected).State = System.Data.Entity.EntityState.Deleted;

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
