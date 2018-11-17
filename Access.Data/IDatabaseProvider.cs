using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Access.Data
{
    public interface IDatabaseProvider
    {
        void CallStoredProcedure(string schema, string procedureName, object parameters);
    }
}
