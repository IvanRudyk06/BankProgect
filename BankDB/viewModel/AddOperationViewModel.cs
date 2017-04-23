using Mvvm.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BankDB.viewModel
{


    class AddOperationViewModel : INotifyPropertyChanged
    {
        IAcountsViewModel iMainWindow;
        Window window;

        public event PropertyChangedEventHandler PropertyChanged;
        private Acount activeAcount;
        public Operation ActiveOperation { get; set; }
        private DelegateCommand commandNewOperation;

        public AddOperationViewModel(Acount acount, IAcountsViewModel iMainWindow, Window w)
        {
            window = w;
            activeAcount = acount;
            ActiveOperation = new Operation();
            ActiveOperation.IdAcount = acount.IdAcount;
            this.iMainWindow = iMainWindow;
        }

        public DelegateCommand CommandNewOperation
        {
            get
            {
                if (commandNewOperation == null)
                {
                    commandNewOperation = new DelegateCommand(newOperation);
                }
                return commandNewOperation;
            }
        }

        private void newOperation()
        {
            using(bankDatabaseEntities db = new bankDatabaseEntities())
            {
                ActiveOperation.DateOperation = DateTime.Now;
                db.Operation.Add(ActiveOperation);
                db.SaveChanges();
            }
            //    MessageBox.Show("Acount " + activeAcount.NameClient + " ");
            refreshOperation(ActiveOperation);
        }

        public void refreshOperation(Operation op)
        {
            //MainWindow mw = new MainWindow();
            //mw.Show();
            window.Close();
            iMainWindow.refreshOperation(op);
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
