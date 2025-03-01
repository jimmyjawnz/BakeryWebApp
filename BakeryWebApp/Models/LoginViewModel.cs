namespace BakeryWebApp.Models
{
    public class LoginViewModel
    {
        public Employee? CurrentEmployee { get; set; } = null;

        public string EmployeeName { get; set; }
        public string EmployeePassword { get; set; }
    }
}
