using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA3000.Database
{
    abstract class IMapper
    {
        IDataBase database;

        protected IMapper(IDataBase database)
        {
            this.database = database;
        }

        public IDataBase Database { get => database; }
    }
}
