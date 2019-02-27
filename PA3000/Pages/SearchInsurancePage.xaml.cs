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
    /// Interaktionslogik für SearchInsurancePage.xaml
    /// </summary>
    public partial class SearchInsurancePage : Page
    {
        Insurance currentInsurance;

        public SearchInsurancePage()
        {
            InitializeComponent();
        }

        class GridItem
        {
            public UInt32 id { get; set; }
            public string Bezeichnung { get; set; }
        }       


        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = searchTb.Text;
            List<Insurance> insurances = new List<Insurance>();

            Database.IInsuranceMapper mapper = PatientanlegerApp.Db.GetInsuranceMapper();
            mapper.SelectByName(name, ref insurances);

            InsuranceDg.Items.Clear();

            foreach (var insurance in insurances)
            {
                InsuranceDg.Items.Add(insurance);
            }
        }

        private void InsuranceDg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (currentInsurance != null && currentInsurance.Dirty)
            {
                MessageBoxResult result = MessageBox.Show("Es gibt ungespeicherte Veränderungen. Fortfahren?", "PA3000", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    currentInsurance = (Insurance)InsuranceDg.SelectedItem;
                    UpdateView();
                    currentInsurance.Dirty = false;
                }
            }
            else
            {
                currentInsurance = (Insurance)InsuranceDg.SelectedItem;
                UpdateView();
                currentInsurance.Dirty = false;
            }
            
        }

        private void SaveInsuranceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!currentInsurance.Dirty) // nothing changed
                return;

            UpdateModel();

            Database.IInsuranceMapper mapper = PatientanlegerApp.Db.GetInsuranceMapper();
            if (!mapper.UpdateSingle(currentInsurance))
                MessageBox.Show("Es ist ein Fehler aufgetreten");

            currentInsurance.Dirty = false;
        }

        private void UpdateView()
        {
            if (currentInsurance == null)
                return;

            NameTb.Text = currentInsurance.Name;
            tbCity.Text = currentInsurance.City;
            tbCountry.Text = currentInsurance.Country;
            tbStreet.Text = currentInsurance.Street;
            tbStreetnumber.Text = currentInsurance.Streetnumber;
            tbZip.Text = currentInsurance.Zipcode;

            if (currentInsurance.Is_Private == 1)
            {
                cbPrivate.IsChecked = true;
            }
            else
            {
                cbPrivate.IsChecked = false;
            }
        }

        private void UpdateModel()
        {
            if (currentInsurance == null)
                return;

            if (!currentInsurance.Dirty)
                return;

            currentInsurance.Name = NameTb.Text;
            currentInsurance.City = tbCity.Text;
            currentInsurance.Country = tbCountry.Text;
            currentInsurance.Street = tbStreet.Text;
            currentInsurance.Streetnumber = tbStreetnumber.Text;
            currentInsurance.Zipcode = tbZip.Text;

            if(cbPrivate.IsChecked == true)
            {
                currentInsurance.Is_Private = 1;
            }
            else
            {
                currentInsurance.Is_Private = 0;
            }
        }

        private void NameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentInsurance == null)
                return;

            currentInsurance.Dirty = true;
        }

        private void tbCountry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentInsurance == null)
                return;

            currentInsurance.Dirty = true;
        }

        private void tbZip_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentInsurance == null)
                return;

            currentInsurance.Dirty = true;
        }

        private void tbCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentInsurance == null)
                return;

            currentInsurance.Dirty = true;
        }

        private void tbStreet_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentInsurance == null)
                return;

            currentInsurance.Dirty = true;
        }

        private void tbStreetnumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentInsurance == null)
                return;

            currentInsurance.Dirty = true;
        }

        private void cbPrivate_Checked(object sender, RoutedEventArgs e)
        {
            if (currentInsurance == null)
                return;

            currentInsurance.Dirty = true;
        }
        private void btCreateInsurance_Click(object sender, RoutedEventArgs e)
        {
            PatientanlegerApp.Mainwindow.contentFrame.Source = new Uri("Pages\\CreateInsurancePage.xaml", UriKind.Relative);
        }
    }
}
