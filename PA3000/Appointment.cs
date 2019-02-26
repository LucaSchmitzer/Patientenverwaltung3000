using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;
using System.Data;

namespace PA3000
{
    abstract class IAppointmentMapper
    {
        public abstract Appointment SelectbyId(UInt32 id);
        public abstract void SelectFromPatient(ref List<Appointment> appointments, UInt32 patientid, DateTime? upperDate, DateTime? lowerDate);
        public abstract int Insert(Appointment data);
        public abstract bool UpdateSingle(Appointment data);
        
    }

    class AppointmentMapperSqlite : IAppointmentMapper
    {
        public static void CreateTable(SQLiteConnection con)
        { 
            con.Execute("CREATE TABLE IF NOT EXISTS Appointments ( AppointmentId INTEGER PRIMARY KEY, PatientId INTEGER NOT NULL, Description TEXT, Date TEXT)");         
        }

        public override int Insert(Appointment appointment)
        {
            if (appointment == null)
                return 0;

            using (IDbConnection con = Application.Db.GetConnection())
            {
                return con.Execute("Insert Into Appointments( PatientId, Description,  Date) values( @PatientId, @Description, @Date)", appointment);
            }
        }

        public override Appointment SelectbyId(UInt32 _id)
        {
            using (IDbConnection con = Application.Db.GetConnection())
            {
                return con.Query<Appointment>("Select * Appointments WHERE InsuranceId = @_id", new { _id }).SingleOrDefault();
            }
        }

        public override void SelectFromPatient(ref List<Appointment> appointments, UInt32 patientid, DateTime? upperDate, DateTime? lowerDate)
        {
            using (IDbConnection con = Application.Db.GetConnection())
            {
                appointments.Clear();

                if (upperDate == null && lowerDate == null)
                {
                    appointments = con.Query<Appointment>("Select * from Appointments WHERE PatientId like @patientid", new { patientid }).ToList();
                }
                else
                {                
                string ld = Utility.DateTimeToSQLite(lowerDate);
                string ud = Utility.DateTimeToSQLite(upperDate);
                appointments = con.Query<Appointment>("Select * from Appointments WHERE PatientId like @patientid AND Date between '" + ld + "' AND '" + ud + "'", new { patientid }).ToList();
                }
            }
        }

        public override bool UpdateSingle(Appointment appointment)
        {
            if (appointment == null)
                return false;

            int rowcount = 0;
            using (IDbConnection con = Application.Db.GetConnection())
            {
                rowcount = con.Execute("Update Appointments SET PatientId = @PatientId, Date = @Date, Description = @Description WHERE AppointmentId = @AppointmentId", appointment);
            }

            if (rowcount != 1)
            {
                return false;
            }

            return true;
        }
    }


    class Appointment
    {
        Appointment(UInt32 _id)
        {
            appointmentId = _id;
            dirty = false;
        }

        UInt32 appointmentId;
        string description;
        UInt32 patientId;
        DateTime? date;
        public Appointment() { dirty = false; }

        bool dirty;


        public UInt32 AppointmentId
        {
            get
            {
                return this.appointmentId;
            }
            set
            {
                this.appointmentId = value;
                dirty = true;
            }
        }

        public UInt32 PatientId
        {
            get
            {
                return this.patientId;
            }
            set
            {
                this.patientId = value;
                dirty = true;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
                dirty = true;
            }
        }

        public DateTime? Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
                dirty = true;
            }
        }

        public bool Dirty
        {
            get
            {
                return this.dirty;
            }
            set
            {
                this.dirty = value;
            }
        }
    }
}