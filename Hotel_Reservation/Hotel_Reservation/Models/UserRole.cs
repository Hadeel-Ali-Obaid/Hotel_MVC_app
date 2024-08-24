﻿using System;
using System.Collections.Generic;

namespace Hotel_Reservation.Models;

public partial class UserRole
{
    public decimal Id { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();
}
