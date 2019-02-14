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

    abstract class IPatientMapper
    {
        public abstract Patient SelectbyId(UInt32 id);
        public abstract void SelectByName(string _name, ref List<Patient> patients);
        public abstract int Insert(Patient data);
        public abstract bool UpdateSingle(Patient data);
    }

    class PatientMapperSqlite : IPatientMapper
    {  
        public override int Insert(Patient patient)
        {
            if (patient == null)
                return 0;
           
            using (IDbConnection con = Global.db.GetConnection())
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
            using (IDbConnection con = Global.db.GetConnection())
            {
                return con.Query<Patient>("Select * Patients WHERE PatientId = @_id", new { _id }).SingleOrDefault();
            }
        }

        public override void SelectByName(string _name,ref List<Patient> patients)
        {
            using (IDbConnection con = Global.db.GetConnection())
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
            using (IDbConnection con = Global.db.GetConnection())
            {              
                rowcount = con.Execute("Update Patients SET FirstName = @FirstName, LastName = @LastName, Birthday = @Birthday, City = @City, Street = @Street, Streetnumber = @Streetnumber, Zipcode = @Zipcode, Country = @Country , InsuranceId = @InsuranceId WHERE PatientId =@PatientId",patient);                
            }

            if(rowcount != 1)
            {
                // shit happend
                return false;
            }           

            return true;
        }
    }
    
    class Patient
    {
        public Patient(UInt32 _id)
        {
            patientId = _id;
            dirty = false;
        }

        public Patient() {dirty = false; }

        UInt32 patientId;
        string firstName;
        string lastName;
        UInt32 insuranceId;
        DateTime? birthday;
        DateTime? createdDate;
        string street;
        string streetnumber;
        string country;
        string zipcode;
        string city;
        bool dirty;
        
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

        public DateTime? Birthday
        {
            get
            {
                return this.birthday;
            }
            set
            {
                this.birthday = value;
                dirty = true;
            }
        }

        public DateTime? CreatedDate
        {
            get
            {
                return this.createdDate;
            }
            set
            {
                this.createdDate = value;
                dirty = true;
            }
        }
        public UInt32 InsuranceId
        {
            get
            {
                return this.insuranceId;
            }
            set
            {
                this.insuranceId = value;
                dirty = true;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
                dirty = true;
            }
        }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
                dirty = true;
            }
        }

        public string Street
        {
            get
            {
                return this.street;
            }
            set
            {
                this.street = value;
                dirty = true;
            }
        }

        public string Streetnumber
        {
            get
            {
                return this.streetnumber;
            }
            set
            {
                this.streetnumber = value;
                dirty = true;
            }
        }

        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
                dirty = true;
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                this.country = value;
                dirty = true;
            }
        }

        public string Zipcode
        {
            get
            {
                return this.zipcode;
            }
            set
            {
                this.zipcode = value;
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
