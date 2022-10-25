using BitLayer.Domain.Dt;
using BitLayer.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitLayer.Dal.Repo
{
    public interface IDepartmentRepository
    {
        Task<List<DepatrmentPartial>> GetDepartmentAsync(DatatableListingRequest request);
    }
}
