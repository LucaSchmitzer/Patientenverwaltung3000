using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace PA3000.Database
{
    abstract class IDataBase
    {
        protected string path;
        public abstract bool Init();
        public abstract string GetPath();     
        public abstract IDbConnection GetConnection();

        public abstract IPatientMapper GetPatientMapper();
        public abstract IInsuranceMapper GetInsuranceMapper();
        public abstract IAppointmentMapper GetAppointmentMapper();
    }
}
