using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA3000.Database
{
    abstract class IAppointmentMapper : IMapper
    {
        protected IAppointmentMapper(IDataBase db) : base(db)
        {
    
        }

        public abstract Appointment SelectbyId(UInt32 id);
        public abstract void SelectFromPatient(ref List<Appointment> appointments, UInt32 patientid, DateTime? upperDate, DateTime? lowerDate);
        public abstract int Insert(Appointment data);
        public abstract bool UpdateSingle(Appointment data);
    }
}
