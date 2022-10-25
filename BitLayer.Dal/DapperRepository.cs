using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitLayer.Dal
{
    public class DapperRepository : IDapperRepository
    {
        
        private readonly string constring;

        public DapperRepository(IConfiguration configuration)
        {
            
            constring = configuration.GetConnectionString("default");
        }




        public IEnumerable<T> ReturnList<T>(string procrdureName, DynamicParameters parameter)
        {
            using (SqlConnection sqlCon = new SqlConnection(constring))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procrdureName, parameter, commandType: CommandType.StoredProcedure);
            }

        }




        public int ReturnInt(string procrdureName, DynamicParameters parameter)
        {
            using (SqlConnection sqlCon = new SqlConnection(constring))
            {
                sqlCon.Open();
                sqlCon.Execute(procrdureName, parameter, commandType: CommandType.StoredProcedure);
                return parameter.Get<int>("Id");

            }
        }





        public T ExecuteReturnScalar<T>(string procrdureName, DynamicParameters parameter)
        {
            using (SqlConnection sqlCon = new SqlConnection(constring))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.Execute(procrdureName, parameter, commandType: CommandType.StoredProcedure), typeof(T));
            }

        }

    }
}
