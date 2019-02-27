using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using System.Data;
using PA3000.Database;

namespace PA3000.Sqlite
{
    class SqliteDatabase : Database.IDataBase
    {
        public SqliteDatabase(string path)
        {
            this.path = path;
        }
        
        public override IDbConnection GetConnection()
        {
            return new SQLiteConnection("Data Source = " + GetPath());
        }      

        public override string GetPath()
        {            
            return Environment.CurrentDirectory + "\\" + path;            
        }

        public override IPatientMapper GetPatientMapper()
        {
            return new PatientMapperSqlite(this);
        }

        public override IInsuranceMapper GetInsuranceMapper()
        {
            return new InsuranceMapperSqlite(this);
        }

        public override IAppointmentMapper GetAppointmentMapper()
        {
            return new AppointmentMapperSqlite(this);
        }

        public override bool Init()
        {
            if (!File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);

                SQLiteConnection dbConnection = new SQLiteConnection("Data Source = " + path + "; Version = 3;");
                dbConnection.Open();
                dbConnection.ChangePassword(String.Empty);
                AppointmentMapperSqlite.CreateTable(dbConnection);
                PatientMapperSqlite.CreateTable(dbConnection);
                InsuranceMapperSqlite.CreateTable(dbConnection);
                dbConnection.Close();
            }
            else
            {
                try
                {
                    using (var con = GetConnection())
                    {
                        con.Open();
                        con.Close();
                    }
                }
                catch
                {
                    return false;
                }
            }

            //SqlMapper.AddTypeHandler<DateTime?>(new NullableDateTimehandler());

            return true;
        }
    }
}
