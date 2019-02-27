using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA3000.Database
{
    abstract class IInsuranceMapper : IMapper
    {
        protected IInsuranceMapper(IDataBase db) :  base(db)
        {
        }

        public abstract Insurance SelectbyId(UInt32 id);
        public abstract void SelectByName(string _name, ref List<Insurance> insurances);
        public abstract int Insert(Insurance data);
        public abstract bool UpdateSingle(Insurance data);
        public abstract void SelectAllNames(ref List<Insurance> insurancenames);
    }
}
