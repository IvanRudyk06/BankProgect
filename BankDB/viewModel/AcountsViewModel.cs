using BankDB.viewModel;
using Mvvm.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace BankDB
{
    class AcountsViewModel: INotifyPropertyChanged, IAcountsViewModel
    {
        Window window;
        private DelegateCommand commandNewClient;
        private DelegateCommand commandUpdateClient;
        private DelegateCommand FilterCommandClients;
        private DelegateCommand FilterCommand;
        private DelegateCommand AddOperationCommand;
        public event PropertyChangedEventHandler PropertyChanged;

        bankDatabaseEntities db = new bankDatabaseEntities();
        
        private Acount selectedAcount;
        private List<Client> Clients;
        public ICollectionView ActiveAcountOperation { get; set; }
        public ICollectionView ListClients { get; set; }
        private Client selectedClient;
        public ICollectionView Acounts { get; set; }
        public string FilterTextAcount { get; set; }
        public string FilterTextClient { get; set; }
        

        public AcountsViewModel(Window w)
        {
            window = w;
            FilterTextAcount = "";
            FilterTextClient = "";
            ActiveAcountOperation = null;
            getAcounts();
            addToListOperation();
            ActiveAcountOperation.Filter = OperationFilter;
            Acounts.Filter = AcountsFilter;
            getClients();
            ListClients.Filter = ClientsFilter;
        }

        public void getAcounts()
        {
            List<Acount> ac = new List<Acount>();
            var typeAcounts = db.AcountType;
            var clients = db.Client;
            var acounts = db.Acount;
            foreach (Acount u in acounts)
            {
                foreach (Client cl in clients)
                {
                    if (u.IdClient == cl.IdClient)
                    {
                        u.Client = cl;
                        break;
                    }
                }
                foreach (AcountType at in typeAcounts)
                {
                    if (u.IdType == at.IdType)
                    {
                        u.AcountType = at;
                        break;
                    }
                }
                ac.Add(u);
            }
            Acounts = CollectionViewSource.GetDefaultView(ac);
        }

        public void getClients()
        {
            Clients = new List<Client>();
            var clients = db.Client;
            foreach (Client u in clients)
            {
                Clients.Add(u);
            }
            ListClients = CollectionViewSource.GetDefaultView(Clients);
        }

        public Acount SelectedAcount
        {
            get { return selectedAcount; }
            set
            {
                selectedAcount = value;
                ActiveAcountOperation.Filter = OperationFilter;
                OnPropertyChanged("SelectedAcount");
            }
        }

        public Client SelectedClient
        {
            get
            {
                return selectedClient;
                
            }
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        List<Operation> listOp;
        public void addToListOperation()
        {
         //   ActiveAcountOperation
            listOp = new List<Operation>();
            var oper = db.Operation;
            foreach (Operation cl in oper)
            {
                listOp.Add(cl);
            }
            ActiveAcountOperation = CollectionViewSource.GetDefaultView(listOp);
        }

        private bool AcountsFilter(object obj)
        {
            bool result = true;
            Acount current = obj as Acount;
            if (current != null)
            {
                string temp = current.NameClient.ToString().ToUpper();
                string temp2 = FilterTextAcount.ToUpper();
                if (!temp.Contains(temp2))
                    result = false;
            }
            return result;
        }

        private bool ClientsFilter(object obj)
        {
            bool result = true;
            Client current = obj as Client;
            if (current != null)
            {
                string temp = current.Name.ToUpper()+current.FirstName.ToUpper();
                string temp2 = FilterTextClient.ToUpper();
                if (!temp.Contains(temp2))
                    result = false;
            }
            return result;
        }

        public bool OperationFilter(object obj)
        {
            bool result = false;
            Operation current = obj as Operation;
            if (current != null)
            {
                if(selectedAcount!=null)
                if (current.IdAcount == selectedAcount.IdAcount)
                    result = true;
            }
            return result;
        }

        private void ChangeFilterClients()
        {
            ListClients.Filter = null;
            ListClients.Filter = ClientsFilter;
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }



        public DelegateCommand GiveFilterCommand
        {
            get
            {
                if (FilterCommand == null)
                {
                    FilterCommand = new DelegateCommand(ChangeFilterAcount);
                }
                return FilterCommand;
            }
        }

        private void ChangeFilterAcount()
        {
            Acounts.Filter = null;
            Acounts.Filter = AcountsFilter;
        }


        public DelegateCommand GiveFilterCommandClients
        {
            get
            {
                if (FilterCommandClients == null)
                {
                    FilterCommandClients = new DelegateCommand(ChangeFilterClients);
                }
                return FilterCommandClients;
            }
        }        

        public DelegateCommand CommandUpdateClient
        {
            get
            {
                if (commandUpdateClient == null)
                {
                    commandUpdateClient = new DelegateCommand(updateClient);
                }
                return commandUpdateClient;
            }
        }

        private void updateClient()
        {
            if(SelectedClient.IdClient!= 0)
            {
                Client cl = SelectedClient;
                db.SaveChanges();
            }
            else
            {
                try
                {
                    Client cl = SelectedClient.Clone() as Client;
                    db.Client.Add(cl);
                    db.SaveChanges();
                    Clients.Add(cl);
                    ListClients = CollectionViewSource.GetDefaultView(Clients);
                    ListClients.Filter = ClientsFilter;
                    SelectedClient = cl;
                }
                catch
                {
                    MessageBox.Show("Input corectly data for\n add new client");
                }
                
            }
            
        }

        public DelegateCommand CommandNewClient
        {
            get
            {
                if (commandNewClient == null)
                {
                    commandNewClient = new DelegateCommand(newClient);
                }
                return commandNewClient;
            }
        }

        private void newClient()
        {
            SelectedClient = null;
            SelectedClient = new Client();
            OnPropertyChanged("SelectedClient");
        }

        public DelegateCommand ComAddOperationWShow
        {
            get
            {
                if (AddOperationCommand == null)
                {
                    AddOperationCommand = new DelegateCommand(addOperationWindowShow, canAddOperation);
                }
                return AddOperationCommand;
            }
        }

        private void addOperationWindowShow()
        {
            AddOpration addOp = new AddOpration(SelectedAcount, this);
            addOp.ShowDialog();
        }

        private bool canAddOperation()
        {
            if (SelectedAcount != null)
            {
                return true;
            }
            else return false;
        }

        public void refreshOperation(Operation op)
        {
            listOp.Add(op);
            ActiveAcountOperation = CollectionViewSource.GetDefaultView(listOp);
            ActiveAcountOperation.Filter = OperationFilter;
            Thread.Sleep(1000);
            OnPropertyChanged("SelectedAcount");
            //window.Hide();
        }
    }
}
