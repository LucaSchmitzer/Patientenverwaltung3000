using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA3000.Database;
using Dapper;
using System.Data.SQLite;

namespace PA3000.Sqlite
{
    class AppointmentMapperSqlite : IAppointmentMapper
    {
        public AppointmentMapperSqlite(IDataBase db) : base(db)
        {
        }

        public static void CreateTable(SQLiteConnection con)
        {
            con.Execute("CREATE TABLE IF NOT EXISTS Appointments ( AppointmentId INTEGER PRIMARY KEY, PatientId INTEGER NOT NULL, Description TEXT, Date TEXT)");
        }

        public override int Insert(Appointment appointment)
        {
            if (appointment == null)
                return 0;

            using (SQLiteConnection con = (SQLiteConnection)Database.GetConnection())
            {
                return con.Execute("Insert Into Appointments( PatientId, Description,  Date) values( @PatientId, @Description, @Date)", appointment);
            }
        }

        public override Appointment SelectbyId(UInt32 _id)
        {
            using (SQLiteConnection con = (SQLiteConnection)Database.GetConnection())
            {
                return con.Query<Appointment>("Select * Appointments WHERE InsuranceId = @_id", new { _id }).SingleOrDefault();
            }
        }

        public override void SelectFromPatient(ref List<Appointment> appointments, UInt32 patientid, DateTime? upperDate, DateTime? lowerDate)
        {
            using (SQLiteConnection con = (SQLiteConnection)Database.GetConnection())
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
            using (SQLiteConnection con = (SQLiteConnection)Database.GetConnection())
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
}
