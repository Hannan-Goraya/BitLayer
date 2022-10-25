



namespace BitLayer.Domain.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string EmployeeDecription { get; set; }

        public string Address { get; set; }

        public DateTime JoingDate { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }

        public string Image { get; set; }
        


        public string City { get; set; }

        public int Phone { get; set; }

        public decimal Salary { get; set; }
    }
}
