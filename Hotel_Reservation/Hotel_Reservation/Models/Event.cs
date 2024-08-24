using System;
using System.Collections.Generic;

namespace Hotel_Reservation.Models;

public partial class Event
{
    public decimal Id { get; set; }

    public string? ImagePath { get; set; }

    public decimal? HotelId { get; set; }

    public decimal? UserLoginId { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual UserLogin? UserLogin { get; set; }
}
