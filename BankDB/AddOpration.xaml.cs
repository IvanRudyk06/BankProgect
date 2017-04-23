using BankDB.viewModel;
using System;
using System.Collections.Generic;
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

namespace BankDB
{
    /// <summary>
    /// Interaction logic for AddOpration.xaml
    /// </summary>
    public partial class AddOpration : Window
    {
        
        
        public AddOpration(Acount acount, IAcountsViewModel iMainWindow)
        {
            InitializeComponent();
            comboBox.Items.Add("Add");
            comboBox.Items.Add("Take");
            DataContext = new AddOperationViewModel(acount, iMainWindow, this);
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
