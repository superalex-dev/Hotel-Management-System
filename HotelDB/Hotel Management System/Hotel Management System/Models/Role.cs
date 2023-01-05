﻿using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    namespace Hotel.Models
    {
        public class Role
        {
            [Key]
            public int RoleId { get; set; }
            public string RoleName { get; set; }
        }
    }
}
