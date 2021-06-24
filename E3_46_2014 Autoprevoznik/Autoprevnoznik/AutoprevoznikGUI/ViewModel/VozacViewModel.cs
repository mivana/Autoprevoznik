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
    public class VozacViewModel 
    {
        public bool _canExecute;

        public VozacView view = VozacView.view;

        public BindingList<Model.Vozac> VozacBindingList { get; set; }
        public List<Model.Vozac> VozacList { get; set; }

        public Vozac selected { get; set; }

        public ICommand voziCommand { get; set; }
        public ICommand editCommand { get; set; }
        public ICommand removeCommand { get; set; }
        public ICommand refreshCommand { get; set; }

        public VozacViewModel()
        {
            _canExecute = true;

            selected = new Vozac();

            RefreshList();
        }

        public void RefreshList()
        {
            VozacList = new List<Vozac>();

            using (var db = new AutoprevoznikDBEntities())
            {
                VozacList = db.Vozacs.ToList();
            }

            VozacBindingList = new BindingList<Vozac>(VozacList);

            view.dataGrid.ItemsSource = null;
            view.dataGrid.ItemsSource = VozacBindingList;
        }

        public ICommand VoziCommand
        {
            get
            {
                return voziCommand ?? (voziCommand = new CommandHandler(() => OnVozi(), _canExecute));
            }
        }

        public void OnVozi()
        {
            if (view.dataGrid.SelectedItem == null)
            {
                view.result.Text = "ERROR: Please first select what entity you want to edit";
            }
            else
            {
                selected = (Vozac)view.dataGrid.SelectedItem;
                AEVoziView newView = new AEVoziView(selected,this);
                newView.ShowDialog();
            }
            
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
                selected = (Vozac)view.dataGrid.SelectedItem;
                AEVozacView newView = new AEVozacView(false, selected, this);
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
                selected = (Vozac)view.dataGrid.SelectedItem;
                using (var db = new AutoprevoznikDBEntities())
                {
                    db.Entry(selected).State = System.Data.Entity.EntityState.Deleted;
                    //db.Vozacs.Attach(selected);
                    //db.Vozacs.Remove(selected);

                    Radnik radnik = db.Radniks.Where(r => r.mbr_r == selected.mbr_r).First();
                    db.Entry(radnik).State = System.Data.Entity.EntityState.Deleted;

                    db.SaveChanges();
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
