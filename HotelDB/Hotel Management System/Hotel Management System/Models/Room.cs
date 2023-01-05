using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    namespace Hotel.Models
    {
        public class Room
        {
            [Key]
            public int RoomNumber { get; set; }
            public string RoomType { get; set; }
            public int Capacity { get; set; }
            public decimal Rate { get; set; }
        }
    }

}
