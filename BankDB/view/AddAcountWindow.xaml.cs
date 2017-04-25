using BankDB.model;
using BankDB.viewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankDB.view
{
    /// <summary>
    /// Interaction logic for AddAcount.xaml
    /// </summary>
    public partial class AddAcountWindow : Window
    {
        public AddAcountWindow(Client selectedClient, IAcountsViewModel view)
        {
            InitializeComponent();
            ObservableCollection<AcountType> typeAc = new ObservableCollection<AcountType>();
            using(bankDatabaseEntities db = new bankDatabaseEntities())
            {
                var at = db.AcountType;
                foreach(AcountType a in at)
                {
                    comboBox.Items.Add(a);
                    typeAc.Add(a);
                }

            }
            DataContext = new AddAcountViewModel(this, selectedClient, typeAc, view);
        }
    }
}
