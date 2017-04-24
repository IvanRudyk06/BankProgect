using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankDB.viewModel
{
    class AddAcountViewModel : INotifyPropertyChanged
    {
        Window window;

        public AddAcountViewModel(Window w)
        {
            window = w;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
