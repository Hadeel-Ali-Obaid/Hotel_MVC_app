using System;
using System.Collections.Generic;

namespace Hotel_Reservation.Models;

public partial class PaymentDatum
{
    public decimal Id { get; set; }

    public string? CardProvider { get; set; }

    public string? CardNumber { get; set; }

    public decimal Balance { get; set; }

    public string? ExpirationDate { get; set; }

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();
}
