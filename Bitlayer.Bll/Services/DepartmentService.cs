using BitLayer.Dal;
using BitLayer.Dal.Repo;
using BitLayer.Domain.Dt;
using BitLayer.Domain.Models;
using BitLayer.Domain.Request;
using Dapper;
using dataTable.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitlayer.Bll.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepo;
        private readonly IDapperRepository _dapper;

        public DepartmentService(IDapperRepository dapper, IDepartmentRepository departmentRepo)
        {
            _departmentRepo = departmentRepo;
            _dapper = dapper;
        }


        public async Task<DataTableResponse<DepatrmentPartial>> GetDepartmentAsync(DataTableRequest request)
        {
            var req = new DatatableListingRequest()
            {
                PageNo = request.Start,
                PageSize = request.Length,
                SortColumn = request.Order[0].Column,
                SortDirection = request.Order[0].Dir,
                SearchValue = request.Search != null ? request.Search.Value.Trim() : ""
            };

            var depatrments = await _departmentRepo.GetDepartmentAsync(req);

            return new DataTableResponse<DepatrmentPartial>()
            {
                Draw = request.Draw,
                RecordsTotal = depatrments[0].TotalCount,
                RecordsFiltered = depatrments[0].FilteredCount,
                Data = depatrments.ToArray(),
                Error = ""
            };

        }


        public int AddDepartment(Department dep)
        {
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@Id", -1, dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameter.Add("@DepartmentName", dep.DepartmentName);
            parameter.Add("@DepartmentDescription", dep.DepartmentDescription);



           var result =  _dapper.ReturnInt("AddDepartment", parameter);

            if (result > 0)
            {
                
            }

            return result;


        }


        public int GetDepartmentById(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@Id", Id);

            var dep = _dapper.ReturnInt("GetDepartmentById", parameters);

            return dep;

        }



        public int EditDepartment(int Id, Department department)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@Id", Id);
            parameters.Add("@DepartmentName", department.DepartmentName);
            parameters.Add("@DepartmentDescription", department.DepartmentDescription);


            var dep = _dapper.ReturnInt("EditDepartment", parameters);

            return dep;
        }


        public int DeleteDep(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id);


            var dep = _dapper.ReturnInt("DeleteDepartment", parameters);
            return dep;
        }

    }


}
