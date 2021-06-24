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
    public class KondukterViewModel 
    {
        public bool _canExecute;

        public KondukterView view = KondukterView.view;

        public BindingList<Model.Kondukter> KondukterBindingList { get; set; }
        public List<Model.Kondukter> KondukterList { get; set; }

        public Kondukter selected { get; set; }

        public ICommand prodajeCommand { get; set; }
        public ICommand editCommand { get; set; }
        public ICommand removeCommand { get; set; }
        public ICommand refreshCommand { get; set; }

        public KondukterViewModel()
        {
            _canExecute = true;

            selected = new Kondukter();

            RefreshList();
        }

        public void RefreshList()
        {
            KondukterList = new List<Kondukter>();

            using (var db = new AutoprevoznikDBEntities())
            {
                KondukterList = db.Kondukters.ToList();
            }

            KondukterBindingList = new BindingList<Kondukter>(KondukterList);

            view.dataGrid.ItemsSource = null;
            view.dataGrid.ItemsSource = KondukterBindingList;
        }

        public ICommand ProdajeCommand
        {
            get
            {
                return prodajeCommand ?? (prodajeCommand = new CommandHandler(() => OnProdaje(), _canExecute));
            }
        }

        public void OnProdaje()
        {
            if (view.dataGrid.SelectedItem == null)
            {
                view.result.Text = "ERROR: Please first select what entity you want to edit";
            }
            else
            {
                selected = (Kondukter)view.dataGrid.SelectedItem;
                KondukterProdajeView newView = new KondukterProdajeView(selected, this);
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
                    selected = (Kondukter)view.dataGrid.SelectedItem;
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
