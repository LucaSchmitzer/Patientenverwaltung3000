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

    abstract class IInsuranceMapper
    {
        public abstract Insurance SelectbyId(UInt32 id);
        public abstract void SelectByName(string _name, ref List<Insurance> insurances);
        public abstract int Insert(Insurance data);
        public abstract bool UpdateSingle(Insurance data);
        public abstract void SelectAllNames(ref List<Insurance> insurancenames);
    }

    class InsuranceMapperSqlite : IInsuranceMapper
    {
        public override int Insert(Insurance insurance)
        {
            if (insurance == null)
                return 0;

            using (IDbConnection con = Global.db.GetConnection())
            {
                return con.Execute("Insert Into Insurances(Name, Is_Private, Country, City, Street, Streetnumber, Zipcode) values(@Name, @Is_Private, @Country, @City, @Street, @Streetnumber, @Zipcode)", insurance);
            }
        }

        public static void CreateTable(SQLiteConnection con)
        {
            con.Execute("CREATE TABLE IF NOT EXISTS Insurances( InsuranceId INTEGER PRIMARY KEY, Name TEXT, City TEXT, Street TEXT, Streetnumber TEXT, Zipcode TEXT, Country TEXT, Is_Private INTEGER)");
        }

        public override void SelectAllNames(ref List<Insurance> insurances)
        {
            using (IDbConnection con = Global.db.GetConnection())
            {
                insurances = con.Query<Insurance>("Select InsuranceId, Name FROM Insurances").ToList();
            }
        }

        public override Insurance SelectbyId(UInt32 _id)
        {
            using (IDbConnection con = Global.db.GetConnection())
            {
                return con.Query<Insurance>("Select * Insurances WHERE InsuranceId = @_id", new { _id }).SingleOrDefault();
            }
        }

        public override void SelectByName(string _name, ref List<Insurance> insurances)
        {
            using (IDbConnection con = Global.db.GetConnection())
            {
                insurances.Clear();
                insurances = con.Query<Insurance>("Select * from Insurances WHERE Name like @name", new { name = "%" + _name + "%" }).ToList();
            }
        }

        public override bool UpdateSingle(Insurance insurance)
        {
            if (insurance == null)
                return false;

            int rowcount = 0;
            using (IDbConnection con = Global.db.GetConnection())
            {
                rowcount = con.Execute("Update Insurances SET Name = @Name, City = @City, Street = @Street, Streetnumber = @Streetnumber, Zipcode = @Zipcode, Country = @Country, Is_Private = @Is_Private WHERE InsuranceId = @InsuranceId", insurance);
            }

            if (rowcount != 1)
            {
                return false;
            }

            return true;
        }
    }


    class Insurance
    {
        Insurance(UInt32 _id)
        {
            insuranceId = _id;
            dirty = false;
        }

        public Insurance() { dirty = false; }
        string street;
        string streetnumber;
        string country;
        string zipcode;
        string city;
        int is_Private;
        UInt32 insuranceId;
        string name;
        bool dirty;


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

        public int Is_Private
        {
            get
            {
                return this.is_Private;
            }
            set
            {
                this.is_Private = value;
                dirty = true;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
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
