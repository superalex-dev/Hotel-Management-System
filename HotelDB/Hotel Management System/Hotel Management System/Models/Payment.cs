using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    namespace Hotel.Models
    {
        public class Payment
        {
            [Key]
            public int PaymentId { get; set; }
            public int BookingId { get; set; }
            public decimal Amount { get; set; }
            public string PaymentMethod { get; set; }
        }
    }

}
