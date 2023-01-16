﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

[Table("StaffRole")]
public class StaffRole
{
    public int StaffID { get; set; }
    public int RoleID { get; set; }

    public virtual Staff Staff { get; set; }
    public virtual Role Role { get; set; }
}