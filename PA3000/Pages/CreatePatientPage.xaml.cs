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
    /// Interaktionslogik für CreatePatientPage.xaml
    /// </summary>
    public partial class CreatePatientPage : Page
    {
        IPatientMapper mapper;

        public CreatePatientPage()
        {
            InitializeComponent();
            mapper = new PatientMapperSqlite();
            UpdateInsuranceCombobox();
        }

        // for insurancecombobox
        private void UpdateInsuranceCombobox()
        {
            List<Insurance> insurances = new List<Insurance>();
            IInsuranceMapper mapper = new InsuranceMapperSqlite();

            mapper.SelectAllNames(ref insurances);
            InsuranceCb.Items.Clear();
            InsuranceCb.DisplayMemberPath = @"Name";

            foreach (var insurance in insurances)
            {
                InsuranceCb.Items.Add(insurance);   
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = new Patient();
            patient.Birthday = BirthdayDp.SelectedDate;
            patient.FirstName = FirstnameTb.Text;
            patient.LastName = LastnameTb.Text;
            patient.Country = tbCountry.Text;
            patient.City = tbCity.Text;
            patient.Street = tbStreet.Text;
            patient.Streetnumber = tbStreetnumber.Text;
            patient.Zipcode = tbZip.Text;

            if (InsuranceCb.SelectedItem != null)
            {
                Insurance selectedEntry = (Insurance)InsuranceCb.SelectedItem;
                patient.InsuranceId = selectedEntry.InsuranceId;
            }
            else
            {
                patient.InsuranceId = 0;
            }

            var date = DateTime.Now;
            date = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Kind);
            patient.CreatedDate = date;

            if(mapper.Insert(patient) == 1)
            {
                MessageBox.Show("Patient wurde angelegt", "Patientenanleger 3000");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.Get().contentFrame.Source = new Uri("Pages\\SearchPatientPage.xaml", UriKind.Relative);
        }
    }
}
