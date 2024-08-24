using System;
using System.Collections.Generic;

namespace Hotel_Reservation.Models;

public partial class ContactU
{
    public decimal Id { get; set; }

    public decimal? UserId { get; set; }

    public string? Case { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    public virtual UserLogin? User { get; set; }
}
