using BitLayer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitLayer.Domain.Dt
{
    public partial class EmployeePartial
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string EmployeeDecription { get; set; }

        public string Address { get; set; }

        public DateTime JoingDate { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }

        public string Image { get; set; }
    }
    public partial class EmployeePartial
    {
        public int TotalCount { get; set; }
        public int FilteredCount { get; set; }
    }
}

