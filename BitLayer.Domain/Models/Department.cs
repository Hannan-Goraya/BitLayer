

namespace BitLayer.Domain.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        public string DepartmentName { get; set; }

        public string DepartmentDescription { get; set; }
    }
}
