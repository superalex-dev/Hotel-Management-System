using System;

public class Role
{
    public int RoleID { get; set; }
    public string RoleName { get; set; }

    public virtual ICollection<StaffRole> StaffRoles { get; set; }
}
