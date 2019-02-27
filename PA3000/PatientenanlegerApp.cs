using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PA3000.Database;

namespace PA3000
{
    class PatientanlegerApp
    {
        static MainWindow mainwindow;
        static IDataBase db;

        public static void Init(MainWindow mainwindow)
        {
            db = new Sqlite.SqliteDatabase("pa3000.sqlite");
            if(!db.Init())
            {
                MessageBox.Show("Datenbank konnte nicht initialisiert werden!");
                Environment.Exit(1);
            }            
        }

        public static IDataBase Db { get => db;}
        public static MainWindow Mainwindow { get => mainwindow;}
    }
}

