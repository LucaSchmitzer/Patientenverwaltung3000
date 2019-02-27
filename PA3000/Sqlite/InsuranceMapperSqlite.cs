using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA3000.Database;
using Dapper;
using System.Data.SQLite;
using System.Data;

namespace PA3000.Sqlite
{
    class InsuranceMapperSqlite : IInsuranceMapper
    {
        public InsuranceMapperSqlite(IDataBase db) : base(db)
        {
        }

        public override int Insert(Insurance insurance)
        {
            if (insurance == null)
                return 0;

            using (SQLiteConnection con = (SQLiteConnection)Database.GetConnection())
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
            using (SQLiteConnection con = (SQLiteConnection)Database.GetConnection())
            {
                insurances = con.Query<Insurance>("Select InsuranceId, Name FROM Insurances").ToList();
            }
        }

        public override Insurance SelectbyId(UInt32 _id)
        {
            using (SQLiteConnection con = (SQLiteConnection)Database.GetConnection())
            {
                return con.Query<Insurance>("Select * Insurances WHERE InsuranceId = @_id", new { _id }).SingleOrDefault();
            }
        }

        public override void SelectByName(string _name, ref List<Insurance> insurances)
        {
            using (SQLiteConnection con = (SQLiteConnection)Database.GetConnection())
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
            using (SQLiteConnection con = (SQLiteConnection)Database.GetConnection())
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
}
