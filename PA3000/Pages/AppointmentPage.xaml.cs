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

namespace PA3000.Pages
{
    /// <summary>
    /// Interaktionslogik für AppointmentPage.xaml
    /// </summary>
    public partial class AppointmentPage : Page
    {
        Appointment currentAppointment;
        IAppointmentMapper mapper;
        UInt32 patientid;
        static AppointmentPage instance;

        public static  AppointmentPage Get()
        {
            return instance;
        }

        public void SetPatient(UInt32 patientid)
        {

        }

        public AppointmentPage()
        {
            InitializeComponent();
            mapper = new AppointmentMapperSqlite();
            instance = this;
        }

        class GridItem
        {
            public UInt32 id { get; set; }
            public string date { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UInt32 id = Initialpage.Get().GetPatientId();

            List<Appointment> appointments = new List<Appointment>();
            mapper.SelectFromPatient(ref appointments, id, dpUpperDate.SelectedDate, dpLowerDate.SelectedDate);

            appointmentGrid.Items.Clear();
            foreach (var a in appointments)
            {
                appointmentGrid.Items.Add(a);
            }
        }

        private void UpdateView()
        {
            if (currentAppointment == null)
                return;

            tbDescription.Text = currentAppointment.Description;
            dpDate.SelectedDate = currentAppointment.Date;

        }

        private void UpdateModel()
        {
            if (currentAppointment == null)
                return;

            if (!currentAppointment.Dirty)
                return;

            currentAppointment.Description = tbDescription.Text;
            currentAppointment.Date = dpDate.SelectedDate;
        }

        private void appointmentGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (currentAppointment != null && currentAppointment.Dirty)
            {
                MessageBoxResult result = MessageBox.Show("Es gibt ungespeicherte Veränderungen. Fortfahren?", "PA3000", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    currentAppointment = (Appointment)appointmentGrid.SelectedItem;
                    UpdateView();
                    currentAppointment.Dirty = false;
                }
            }
            else
            {
                currentAppointment = (Appointment)appointmentGrid.SelectedItem;
                UpdateView();
                if(currentAppointment != null) currentAppointment.Dirty = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            if (!currentAppointment.Dirty) // nothing changed
                return;

            UpdateModel();

            if (!mapper.UpdateSingle(currentAppointment))
                MessageBox.Show("Es ist ein Fehler aufgetreten");

            currentAppointment.Dirty = false;
          
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Appointment app = new Appointment();
            UInt32 id = Initialpage.Get().GetPatientId();
            app.PatientId = id;
            app.Description = tbDescription.Text;
            app.Date = dpDate.SelectedDate;

            mapper.Insert(app);          
        }

        private void tbDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentAppointment != null)
                currentAppointment.Dirty = true;
        }

        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (currentAppointment != null)
                currentAppointment.Dirty = true;
        }
    }
}
