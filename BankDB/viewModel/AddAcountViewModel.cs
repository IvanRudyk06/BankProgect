using BankDB.model;
using Mvvm.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankDB.viewModel
{
    class AddAcountViewModel : INotifyPropertyChanged
    {
        private Client selectedClient;
        private AcountType selectedAcountType;
        public AcountType SelectedAcountType
        {
            get
            {
                return selectedAcountType;
            }
            set
            {
                selectedAcountType = value;
                OnPropertyChanged("selected acountType");
            }
        }
        private DelegateCommand addAcountOkCommand;
        public Acount AcountAdding { get; set; }
        Window window;
        IAcountsViewModel view;

        public AddAcountViewModel(Window w, Client selectedClient, ObservableCollection<AcountType> acontType, IAcountsViewModel view)
        {
            this.view = view;
            AcountAdding = new Acount()
            {
                DateClose = DateTime.Now
            };
            
            this.selectedClient = selectedClient;
            window = w;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public DelegateCommand AddAcountOkComand
        {
            get
            {
                if (addAcountOkCommand == null)
                {
                    addAcountOkCommand = new DelegateCommand(addAcount, canAddAcount);
                }
                return addAcountOkCommand;
            }
        }

        private bool canAddAcount()
        {
            if(AcountAdding.Sum != 0 && AcountAdding.DateClose != null 
                && SelectedAcountType != null && AcountAdding.CodeAcount != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void addAcount()
        {
            using (bankDatabaseEntities db = new bankDatabaseEntities())
            {
                AcountAdding.IdClient = selectedClient.IdClient;
                AcountAdding.IdType = SelectedAcountType.IdType;
                AcountAdding.DateOpen = DateTime.Now;
                db.Acount.Add(AcountAdding);
                db.SaveChanges();
            }
            AcountAdding.Client = selectedClient;
            view.refreshAcount(AcountAdding);
            window.Close();
        }
    }
}
