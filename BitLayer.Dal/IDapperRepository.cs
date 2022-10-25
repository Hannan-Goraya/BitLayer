using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitLayer.Dal
{
    public interface IDapperRepository
    {
        IEnumerable<T> ReturnList<T>(string procrdureName, DynamicParameters parameter);

        int ReturnInt(string procrdureName, DynamicParameters parameter);

        T ExecuteReturnScalar<T>(string procrdureName, DynamicParameters parameter);

    }
}
