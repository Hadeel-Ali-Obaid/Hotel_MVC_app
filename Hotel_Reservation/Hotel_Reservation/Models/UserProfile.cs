using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Reservation.Models;

public partial class UserProfile
{
    public decimal Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? ImagePath { get; set; }

    [NotMapped]
    public virtual IFormFile ImageFile { get; set; }

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();
}
