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
    using PA3000.Pages;
    /// <summary>
    /// Interaktionslogik für Initialpage.xaml
    /// </summary>
    public partial class Initialpage : Page
    {

        Patient currentPatient;
        IPatientMapper mapper;
        static Initialpage instance;

        public Initialpage()
        {
            InitializeComponent();
            mapper = new PatientMapperSqlite();
            instance = this;
        }

        public static Initialpage Get()
        {
            return instance;
        }

        public UInt32 GetPatientId()
        {
            return currentPatient.PatientId;
        }



        class GridItem
        {
            public UInt32 id { get; set; }
            public string Vorname { get; set; }
            public string Nachname { get; set; }
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = searchTb.Text;
            List<Patient> patients = new List<Patient>();
            mapper.SelectByName(name, ref patients);

            patientDg.Items.Clear();

            foreach (var patient in patients)
            {
                patientDg.Items.Add(patient);
            }
        }

        private void patientDg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (currentPatient != null && currentPatient.Dirty)
            {
                MessageBoxResult result = MessageBox.Show("Es gibt ungespeicherte Veränderungen. Fortfahren?", "PA3000", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    currentPatient = (Patient)patientDg.SelectedItem;
                    UpdateView();
                    currentPatient.Dirty = false;
                }
            }
            else
            {
                currentPatient = (Patient)patientDg.SelectedItem;
                UpdateView();
                currentPatient.Dirty = false;
            }
            
        }

        private void UpdateView()
        {
            if (currentPatient == null)
                return;

            FirstnameTb.Text = currentPatient.FirstName;
            LastnameTb.Text = currentPatient.LastName;
            BirthdayDp.SelectedDate = currentPatient.Birthday;
            CreatedDateTb.Text = currentPatient.CreatedDate.ToString();
            tbCity.Text = currentPatient.City;
            tbCountry.Text = currentPatient.Country;
            tbStreet.Text = currentPatient.Street;
            tbStreetnumber.Text = currentPatient.Streetnumber;
            tbZip.Text = currentPatient.Zipcode;

            UpdateInsuranceCombobox();
        }

        private void UpdateModel()
        {
            if (currentPatient == null)
                return;

            if (!currentPatient.Dirty)
                return;

            currentPatient.FirstName = FirstnameTb.Text;
            currentPatient.LastName = LastnameTb.Text;
            currentPatient.Birthday = BirthdayDp.SelectedDate;
            currentPatient.City = tbCity.Text;
            currentPatient.Country = tbCountry.Text;
            currentPatient.Street = tbStreet.Text;
            currentPatient.Streetnumber = tbStreetnumber.Text;
            currentPatient.Zipcode = tbZip.Text;




            if (InsuranceCb.SelectedItem != null)
            {
                Insurance selectedEntry = (Insurance)InsuranceCb.SelectedItem;
                currentPatient.InsuranceId = selectedEntry.InsuranceId;
            }
            else
            {
                currentPatient.InsuranceId = 0;
            }
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

                if (insurance.InsuranceId == currentPatient.InsuranceId)
                {
                    InsuranceCb.SelectedItem = insurance;
                }

            }
        }

        private void SavePatientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!currentPatient.Dirty) // nothing changed
                return;

            UpdateModel();

            if (!mapper.UpdateSingle(currentPatient))
                MessageBox.Show("Es ist ein Fehler aufgetreten");

            currentPatient.Dirty = false;
        }      
        private void LastnameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentPatient == null)
                return;

            currentPatient.Dirty = true;
        }

        private void FirstnameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentPatient == null)
                return;

            currentPatient.Dirty = true;
        }

        private void InsuranceCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (currentPatient == null)
                return;

            currentPatient.Dirty = true;
        }

        private void BirthdayDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (currentPatient == null)
                return;

            currentPatient.Dirty = true;
        }

   

        private void tbCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentPatient == null)
                return;

            currentPatient.Dirty = true;
        }

        private void tbCountry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentPatient == null)
                return;

            currentPatient.Dirty = true;
        }

        private void tbZip_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentPatient == null)
                return;

            currentPatient.Dirty = true;
        }

        private void tbStreet_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentPatient == null)
                return;

            currentPatient.Dirty = true;
        }

        private void tbStreetnumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentPatient == null)
                return;

            currentPatient.Dirty = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Get().contentFrame.Source = new Uri("Pages\\CreatePatientPage.xaml", UriKind.Relative);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {            
            MainWindow.Get().contentFrame.Source = new Uri("Pages\\AppointmentPage.xaml", UriKind.Relative);
        }
    }
}
