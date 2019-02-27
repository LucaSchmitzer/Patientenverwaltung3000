using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA3000.Database
{
    abstract class IPatientMapper : IMapper
    {
        protected IPatientMapper(IDataBase db) : base(db)
        {
        }

        public abstract Patient SelectbyId(UInt32 id);
        public abstract void SelectByName(string _name, ref List<Patient> patients);
        public abstract int Insert(Patient data);
        public abstract bool UpdateSingle(Patient data);
    }
}
