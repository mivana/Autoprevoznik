using AutoprevoznikGUI.Model;
using AutoprevoznikGUI.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoprevoznikGUI.ViewModel
{
    public class NaseljeViewModel 
    {

        public bool _canExecute;

        public NaseljeView view = NaseljeView.view;

        public BindingList<Model.Naselje> NaseljeBindingList { get; set; }
        public List<Model.Naselje> NaseljeList { get; set; }

        public Naselje selected { get; set; }

        public BindingList<TabeleVKKEntity> PKBindingList { get; set; }
        public List<TabeleVKKEntity> PKList { get; set; }


        public ICommand addCommand { get; set; }
        public ICommand editCommand { get; set; }
        public ICommand removeCommand { get; set; }
        public ICommand refreshCommand { get; set; }
        public ICommand numPassesCommand { get; set; }

        public NaseljeViewModel()
        {
            _canExecute = true;

            selected = new Naselje();

            RefreshList();
        }

        public void RefreshList()
        {
            NaseljeList = new List<Naselje>();

            using (var db = new AutoprevoznikDBEntities())
            {
                NaseljeList = db.Naseljes.ToList();
            }

            NaseljeBindingList = new BindingList<Naselje>(NaseljeList);

            view.dataGrid.ItemsSource = null;
            view.dataGrid.ItemsSource = NaseljeBindingList;

            PKList = new List<TabeleVKKEntity>();

            using (var db = new AutoprevoznikDBEntities()) {
                foreach (var nas in db.Naseljes.ToList())
                {
                    foreach (var linija in nas.Linijas)
                    {
                        PKList.Add(new TabeleVKKEntity() { Linija = linija.br_linije, Naselje = nas.ime_naselja });
                    }
                }
            }
            PKBindingList = new BindingList<TabeleVKKEntity>(PKList);
            view.dataGridPutujeKroz.ItemsSource = PKBindingList;


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
            AENaseljeView newView = new AENaseljeView(true, this);
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
                selected = (Naselje)view.dataGrid.SelectedItem;
                AENaseljeView aea = new AENaseljeView(false, selected, this);
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
                    selected = (Naselje)view.dataGrid.SelectedItem;
                    using (var db = new AutoprevoznikDBEntities())
                    {
                        db.Entry(selected).State = System.Data.Entity.EntityState.Deleted;
                        //db.Naseljes.Attach(selected);
                        //db.Naseljes.Remove(selected);
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

        public ICommand NumPassedCommand
        {
            get
            {
                return numPassesCommand ?? (numPassesCommand = new CommandHandler(() => OnNumPassed(), _canExecute));
            }
        }

        public void OnNumPassed()
        {
            var result = "";

            try
            {
                using (var db = new AutoprevoznikDBEntities())
                {
                    var data = db.Database.SqlQuery<string>(@"declare @ReturnValue varchar(100);
                                                        exec  dbo.P_Naselje @ReturnValue output
                                                        select @ReturnValue");

                    result = data.First();
                }

                if (result != null)
                {
                    string[] tokens = result.Split(',');
                    view.result.Text = String.Format("INFO: Najposecenije mesto je {0}, poseceno {1} puta.", tokens[0], tokens[1]);
                }
                else
                {
                    view.result.Text = "No result";
                }
            }
            catch (Exception)
            {
                view.result.Text = "Error!";
            }


        }


    }
}
