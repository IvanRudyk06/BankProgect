using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankDB
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AcountsViewModel();
        }

        private void textBox1_Copy2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //var context = new bankDatabaseEntities();

            //AcountType ac = new AcountType();
            //ac.IdType = 5;
            //ac.nameType = "214";
            //ac.interestRate = 2;

            //    context.AcountType.Add(ac);
            //    //context.Entry(ac).State = EntityState.Added;
            //    context.SaveChanges();
        }
    }
    }

