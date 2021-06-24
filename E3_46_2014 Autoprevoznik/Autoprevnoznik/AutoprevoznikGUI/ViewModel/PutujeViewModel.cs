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
    public class PutujeViewModel
    {

        public bool _canExecute;

        public PutujeView view = PutujeView.view;

        public BindingList<Model.Putuje> PutujeBindingList { get; set; }
        public List<Model.Putuje> PutujeList { get; set; }

        public Putuje selected { get; set; }

        public ICommand addCommand { get; set; }
        public ICommand editCommand { get; set; }
        public ICommand removeCommand { get; set; }
        public ICommand refreshCommand { get; set; }

        public PutujeViewModel()
        {
            _canExecute = true;

            selected = new Putuje();

            RefreshList();
        }

        public void RefreshList()
        {
            PutujeList = new List<Putuje>();

            using (var db = new AutoprevoznikDBEntities())
            {
                PutujeList = db.Putujes.ToList();
            }

            PutujeBindingList = new BindingList<Putuje>(PutujeList);

            view.dataGrid.ItemsSource = null;
            view.dataGrid.ItemsSource = PutujeBindingList;
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
            AEPutujeView newView = new AEPutujeView(true, this);
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
                selected = (Putuje)view.dataGrid.SelectedItem;
                AEPutujeView aea = new AEPutujeView(false, selected, this);
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
                    selected = (Putuje)view.dataGrid.SelectedItem;
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
