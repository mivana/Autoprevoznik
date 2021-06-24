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
    public class PutnikViewModel
    {

        public bool _canExecute;

        public PutnikView view = PutnikView.view;

        public BindingList<Model.Putnik> PutnikBindingList { get; set; }
        public List<Model.Putnik> PutnikList { get; set; }

        public Putnik selected { get; set; }

        public ICommand addCommand { get; set; }
        public ICommand editCommand { get; set; }
        public ICommand removeCommand { get; set; }
        public ICommand refreshCommand { get; set; }

        public PutnikViewModel()
        {
            _canExecute = true;

            selected = new Putnik();

            RefreshList();
        }

        public void RefreshList()
        {
            PutnikList = new List<Putnik>();

            using (var db = new AutoprevoznikDBEntities())
            {
                PutnikList = db.Putniks.ToList();
            }

            PutnikBindingList = new BindingList<Putnik>(PutnikList);

            view.dataGrid.ItemsSource = null;
            view.dataGrid.ItemsSource = PutnikBindingList;
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
            AEPutnikView aeview = new AEPutnikView(true, this);
            aeview.ShowDialog();
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
                selected = (Putnik)view.dataGrid.SelectedItem;
                AEPutnikView aeview = new AEPutnikView(false, selected, this);
                aeview.ShowDialog();
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

                    selected = (Putnik)view.dataGrid.SelectedItem;
                    using (var db = new AutoprevoznikDBEntities())
                    {
                        db.Entry(selected).State = System.Data.Entity.EntityState.Deleted;

                        //db.Putniks.Attach(selected);
                        //db.Putniks.Remove(selected);
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
