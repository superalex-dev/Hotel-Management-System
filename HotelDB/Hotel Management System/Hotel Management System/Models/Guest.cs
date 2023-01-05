using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    namespace Hotel.Models
    {
        public class Guest
        {
            [Key]
            public int GuestId { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
        }
    }

}
