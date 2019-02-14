using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.IO;
using Dapper;

namespace PA3000
{
    class SqliteDatabase : IDataBase
    {
        public SqliteDatabase(string _path)
        { 
            path = _path;
            IsValid();
        } 

        public override IDbConnection GetConnection()
        {
            return new SQLiteConnection("Data Source = " + GetPath());
        }
    }

    abstract class IDataBase
    {
        protected string path;
        public bool IsValid()
        {
            if (!File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);

                SQLiteConnection dbConnection = new SQLiteConnection("Data Source = "+path+ "; Version = 3;");
                dbConnection.Open();
                dbConnection.ChangePassword(String.Empty);
                AppointmentMapperSqlite.CreateTable(dbConnection);
                PatientMapperSqlite.CreateTable(dbConnection);
                InsuranceMapperSqlite.CreateTable(dbConnection);
                dbConnection.Close();
            }           
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

            return false;

        }
        public string GetPath()
        {
            return Environment.CurrentDirectory + "\\" + path;
        }
        public abstract IDbConnection GetConnection();
    }
}
