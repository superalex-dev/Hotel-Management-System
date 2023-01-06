using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    namespace Hotel.Models
    {
        public class Employee
        {
            [Key]
            public int EmployeeId { get; set; }
            public string Name { get; set; }
            public int RoleId { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
        }
    }

}
