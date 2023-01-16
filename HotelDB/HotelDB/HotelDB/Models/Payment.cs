using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Payment")]
public class Payment
{
    [Key]
    public int PaymentID { get; set; }
    public int BookingID { get; set; }
    public string PaymentMethod { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }

    public virtual Booking Booking { get; set; }
}
