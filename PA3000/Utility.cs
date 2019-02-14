using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace PA3000
{

    public class NullableDateTimehandler : SqlMapper.TypeHandler<DateTime?>
    {
        public NullableDateTimehandler() { }

        public override DateTime? Parse(object value)
        {
            return Utility.SQLiteToDatetime(value.ToString());
        }

        public override void SetValue(IDbDataParameter parameter, DateTime? value)
        {
            parameter.Value = Utility.DateTimeToSQLite(value);
        }
    }
    
    class Utility
    {
        public static string DateTimeToSQLite(DateTime? _datetime)
        {
            string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}";

            if (_datetime == null)
            {
                //return string.Format(dateTimeFormat, 0, 0, 0, 0, 0, 0, 0, 0);
                return "00.00.0000";
            }
            else
            {
                // not null -> we can convert to a datetime
                DateTime datetime = (DateTime)_datetime;
                return datetime.ToShortDateString();
               // return string.Format(dateTimeFormat, datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second);
            }            
        }

        public static DateTime? SQLiteToDatetime(string datetime)
        {
            if (datetime == "0" || datetime == string.Format("{0}-{1}-{2} {3}:{4}:{5}", 0, 0, 0, 0, 0, 0, 0, 0))
                return null;
            DateTime? dt;
            try
            {
                dt = DateTime.Parse(datetime);
            }
            catch
            {
                dt = null;
            }

            return dt;
        }
    }
}
