using System;
using System.ComponentModel.DataAnnotations;

public class Role
{
    [Key]
    public int RoleID { get; set; }
    public string RoleName { get; set; }

    public virtual ICollection<StaffRole> StaffRoles { get; set; }
}
