using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Booking")]
public class Booking
{
    [Key]
    public int BookingID { get; set; }
    public int RoomID { get; set; }
    public string GuestName { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfGuests { get; set; }
    public decimal TotalCost { get; set; }
    public string PaymentStatus { get; set; }

    public virtual Room Room { get; set; }
    public virtual Payment Payment { get; set; }
}
