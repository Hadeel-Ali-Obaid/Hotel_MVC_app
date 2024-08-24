using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Reservation.Models;

public partial class City
{
    public decimal Id { get; set; }

    public string CityName { get; set; } = null!;

    public string? CityImagePath { get; set; }

    [NotMapped]
    public virtual IFormFile ImageFile { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}
