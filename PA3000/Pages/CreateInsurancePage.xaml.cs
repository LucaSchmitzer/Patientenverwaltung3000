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

namespace PA3000
{
    /// <summary>
    /// Interaktionslogik für CreateInsurancePage.xaml
    /// </summary>
    public partial class CreateInsurancePage : Page
    {
        IInsuranceMapper mapper;
        public CreateInsurancePage()
        {
            InitializeComponent();
            mapper = new InsuranceMapperSqlite();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Insurance insurance = new Insurance();
            insurance.Name = NameTb.Text;
            if (cbPrivate.IsChecked == true)
            {
                insurance.Is_Private = 1;
            }
            else
            {
                insurance.Is_Private = 0;
            }

            insurance.Country = tbCountry.Text;
            insurance.City = tbCity.Text;
            insurance.Street = tbStreet.Text;
            insurance.Streetnumber = tbStreetnumber.Text;
            insurance.Zipcode = tbZip.Text;

            mapper.Insert(insurance);

            MainWindow.Get().contentFrame.Source = new Uri("Pages\\SearchInsurancePage.xaml", UriKind.Relative);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.Get().contentFrame.Source = new Uri("Pages\\SearchInsurancePage.xaml", UriKind.Relative);
        }
    }
}
