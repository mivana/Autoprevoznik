﻿using AutoprevoznikGUI.Model;
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
    public class LinijaViewModel
    {
        public bool _canExecute;

        public LinijaView view = LinijaView.view;

        public BindingList<Model.Linija> LinijaBindingList { get; set; }
        public List<Model.Linija> LinijaList { get; set; }

        public Linija selected { get; set; }

        public ICommand addCommand { get; set; }
        public ICommand editCommand { get; set; }
        public ICommand removeCommand { get; set; }
        public ICommand refreshCommand { get; set; }

        public LinijaViewModel()
        {
            _canExecute = true;

            selected = new Linija();

            RefreshList();
        }

        public void RefreshList()
        {
            LinijaList = new List<Linija>();

            using (var db = new AutoprevoznikDBEntities())
            {
                LinijaList = db.Linijas.ToList();
            }

            LinijaBindingList = new BindingList<Linija>(LinijaList);

            view.dataGrid.ItemsSource = null;
            view.dataGrid.ItemsSource = LinijaBindingList;
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
            AELinijaView newView = new AELinijaView(true, this);
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
                selected = (Linija)view.dataGrid.SelectedItem;
                AELinijaView aea = new AELinijaView(false, selected, this);
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
                    selected = (Linija)view.dataGrid.SelectedItem;
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
