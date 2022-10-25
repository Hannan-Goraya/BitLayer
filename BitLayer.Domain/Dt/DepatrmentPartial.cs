using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitLayer.Domain.Dt
{
    public partial class DepatrmentPartial
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; }

        public string DepartmentDescription { get; set; }
    }
    public partial class DepatrmentPartial
    {
        public int TotalCount { get; set; }
        public int FilteredCount { get; set; }
    }
}
