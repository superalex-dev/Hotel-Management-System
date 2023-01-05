using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    namespace Hotel.Models
    {
        public class Booking
        {
            [Key]
            public int BookingId { get; set; }
            public int GuestId { get; set; }
            public int RoomNumber { get; set; }
            public DateTime CheckIn { get; set; }
            public DateTime CheckOut { get; set; }
        }

    }

}
