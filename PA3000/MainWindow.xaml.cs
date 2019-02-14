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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Dapper;

namespace PA3000
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Global.db = new SqliteDatabase("pa3000.sqlite");
            SqlMapper.AddTypeHandler<DateTime?>(new NullableDateTimehandler());
            instance = this;
        }

        private static MainWindow instance;
        public static MainWindow Get()
        {
            return instance;
        }

        private void searchPatientBtn_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Source = new Uri("Pages\\SearchPatientPage.xaml", UriKind.Relative);
        }



        private void searchInsuranceBtn_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Source = new Uri("Pages\\SearchInsurancePage.xaml", UriKind.Relative);
        }

     
    }
}
