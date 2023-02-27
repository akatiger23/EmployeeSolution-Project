using System.ComponentModel.DataAnnotations;
using EmployeeSolution;


namespace EmployeeSolution.Shared.Modell
{
    public class Employee
    {
        
        [Key]
        public int EmpID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public DateTime CreatDate { get; set; }
        public DateTime? HireDate { get; set; }

        public string? EmployeeStatus { get; set; }
        
    }
}
