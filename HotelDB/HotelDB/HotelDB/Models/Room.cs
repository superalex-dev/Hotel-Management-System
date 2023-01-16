using System;
using System.ComponentModel.DataAnnotations;

public class Room
{
    [Key]
    public int RoomID { get; set; }
    public int HotelID { get; set; }
    public string RoomNumber { get; set; }
    public string RoomType { get; set; }
    public decimal Price { get; set; }
    public bool Available { get; set; }

    public virtual Hotel Hotel { get; set; }
    public virtual ICollection<Booking> Bookings { get; set; }
}
