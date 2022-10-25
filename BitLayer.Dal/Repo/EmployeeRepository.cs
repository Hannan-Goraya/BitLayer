using BitLayer.Domain.Dt;
using BitLayer.Domain.Request;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitLayer.Dal.Repo
{
    public class EmployeeRepository
    {
        private readonly IDapperRepository _dapper;

        public EmployeeRepository(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        public async Task<List<EmployeePartial>> GetDepartmentAsync(DatatableListingRequest request)
        {
            try
            {

                var parameters = new DynamicParameters();
                parameters.Add("SearchValue", request.SearchValue, DbType.String);
                parameters.Add("PageNo", request.PageNo, DbType.Int32);
                parameters.Add("PageSize", request.PageSize, DbType.Int32);
                parameters.Add("SortColumn", request.SortColumn, DbType.Int32);
                parameters.Add("SortDirection", request.SortDirection, DbType.String);


                return  _dapper.ReturnList<EmployeePartial>("GetAllDepartment", parameters).ToList();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
