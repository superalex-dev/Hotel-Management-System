using System;

public class Staff
{
    public int StaffID { get; set; }
    public int HotelID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }

    public virtual Hotel Hotel { get; set; }
    public virtual ICollection<StaffRole> StaffRoles { get; set; }
}