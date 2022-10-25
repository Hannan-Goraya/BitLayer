using BitLayer.Domain.Dt;
using BitLayer.Domain.Models;
using dataTable.Dtos;

namespace Bitlayer.Bll.Services
{
    public interface IDepartmentService
    {
        int AddDepartment(Department dep);
        int DeleteDep(int Id);
        int EditDepartment(int Id, Department department);
        Task<DataTableResponse<DepatrmentPartial>> GetDepartmentAsync(DataTableRequest request);
        int GetDepartmentById(int Id);
    }
}