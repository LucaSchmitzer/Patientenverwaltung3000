using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;
using System.Data;
using PA3000.Database;

namespace PA3000.Sqlite
{
    class PatientMapperSqlite : Database.IPatientMapper
    {
        public PatientMapperSqlite(IDataBase db) : base(db)
        {

        }

        public override int Insert(Patient patient)
        {
            if (patient == null)
                return 0;

            using (SQLiteConnection con = (SQLiteConnection)Database.GetConnection())
            {
                return con.Execute("Insert Into Patients(FirstName, LastName, Birthday, InsuranceId, CreatedDate, Country, City, Street, Streetnumber, Zipcode) values(@FirstName, @LastName, @Birthday, @InsuranceId, @CreatedDate, @Country, @City, @Street, @Streetnumber, @Zipcode)", patient);
            }
        }

        public static void CreateTable(SQLiteConnection con)
        {
            con.Execute("CREATE TABLE IF NOT EXISTS Patients ( PatientId INTEGER PRIMARY KEY, FirstName TEXT, LastName TEXT, Birthday TEXT, CreatedDate NUMERIC, InsuranceId TEXT, Street TEXT, Streetnumber TEXT, Zipcode TEXT, Country TEXT, City TEXT)");
        }

        public override Patient SelectbyId(UInt32 _id)
        {
            using (SQLiteConnection con = (SQLiteConnection)Database.GetConnection())
            {
                return con.Query<Patient>("Select * Patients WHERE PatientId = @_id", new { _id }).SingleOrDefault();
            }
        }

        public override void SelectByName(string _name, ref List<Patient> patients)
        {
            using (SQLiteConnection con = (SQLiteConnection)Database.GetConnection())
            {
                patients.Clear();
                patients = con.Query<Patient>("Select * from Patients WHERE FirstName like @name OR LastName like @name", new { name = "%" + _name + "%" }).ToList();
            }
        }

        public override bool UpdateSingle(Patient patient)
        {
            if (patient == null)
                return false;

            int rowcount = 0;
            using (SQLiteConnection con = (SQLiteConnection)Database.GetConnection())
            {
                rowcount = con.Execute("Update Patients SET FirstName = @FirstName, LastName = @LastName, Birthday = @Birthday, City = @City, Street = @Street, Streetnumber = @Streetnumber, Zipcode = @Zipcode, Country = @Country , InsuranceId = @InsuranceId WHERE PatientId =@PatientId", patient);
            }

            if (rowcount != 1)
            {
                // shit happend
                return false;
            }

            return true;
        }
    }
}
