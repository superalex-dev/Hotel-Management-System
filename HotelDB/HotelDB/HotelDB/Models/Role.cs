using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Role")]
public class Role
{
    [Key]
    public int RoleID { get; set; }
    public string RoleName { get; set; }

    public virtual ICollection<StaffRole> StaffRoles { get; set; }
}
