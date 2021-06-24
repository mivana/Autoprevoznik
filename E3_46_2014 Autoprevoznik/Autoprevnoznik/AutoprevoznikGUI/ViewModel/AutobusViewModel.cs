using AutoprevoznikGUI.Model;
using AutoprevoznikGUI.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AutoprevoznikGUI.ViewModel
{
    public class AutobusViewModel
    {
        public bool _canExecute;

        public AutobusView view = AutobusView.view;

        public BindingList<Model.Autobu> AutobusBindingList { get; set; }
        public List<Model.Autobu> AutobusList { get; set; }
        public List<ResultAutobus> hours { get; set; }

        public Autobu selected { get; set; }

        public ICommand addCommand { get; set; }
        public ICommand editCommand { get; set; }
        public ICommand removeCommand { get; set; }
        public ICommand refreshCommand { get; set; }
        public ICommand hoursDrivenCommand { get; set; }

        public AutobusViewModel()
        {
            _canExecute = true;

            selected = new Autobu();

            RefreshList();
        }

        /// <summary>
        /// Dobavlja najnovije podatke iz baze
        /// </summary>
        public void RefreshList()
        {
            AutobusList = new List<Autobu>();

            using(var db = new AutoprevoznikDBEntities())
            {
                AutobusList = db.Autobus.ToList();
            }

            AutobusBindingList = new BindingList<Autobu>(AutobusList);

            view.dataGrid.ItemsSource = null;
            view.dataGrid.ItemsSource = AutobusBindingList;
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
            view.result.Text = "";
            AEAutobusView aea = new AEAutobusView(true,this);
            aea.ShowDialog();
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
            view.result.Text = "";
            if (view.dataGrid.SelectedItem==null)
            {
                view.result.Text = "ERROR: Please first select what entity you want to edit";
            }
            else
            {
                selected = (Autobu)view.dataGrid.SelectedItem;
                AEAutobusView aea = new AEAutobusView(false, selected, this);
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
            view.result.Text = "";
            if (view.dataGrid.SelectedItem == null)
            {
                view.result.Text = "ERROR: Please first select what entity you want to delete";
            }
            else
            {
                try
                {
                    selected = (Autobu)view.dataGrid.SelectedItem;
                    using (var db = new AutoprevoznikDBEntities())
                    {
                        Autobu found = db.Autobus.Find(selected.reg);
                        db.Entry(found).State = System.Data.Entity.EntityState.Deleted;
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

        public ICommand HoursDrivenCommand
        {
            get
            {
                return hoursDrivenCommand ?? (hoursDrivenCommand = new CommandHandler(() => OnHoursDriven(), _canExecute));
            }
        }

        public void OnHoursDriven()
        {
            hours = new List<ResultAutobus>();
            using (var db = new AutoprevoznikDBEntities())
            {
                ResultView resultView = new ResultView();

                var data = db.Database.SqlQuery<ResultAutobus>(@"exec dbo.P_Autobus_sati");

                var newresult = data.ToList();

                hours = newresult;

                resultView.dataGrid.ItemsSource = hours;
                resultView.Show();

            }
        }


    }
}
