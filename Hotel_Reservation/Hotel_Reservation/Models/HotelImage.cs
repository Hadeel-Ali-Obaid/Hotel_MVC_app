using System;
using System.Collections.Generic;

namespace Hotel_Reservation.Models;

public partial class HotelImage
{
    public decimal Id { get; set; }

    public string? ImagePath { get; set; }

    public decimal? HotelId { get; set; }

    public virtual Hotel? Hotel { get; set; }
}
