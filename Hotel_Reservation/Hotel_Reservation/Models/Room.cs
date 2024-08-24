using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Reservation.Models;

public partial class Room
{
    public decimal Id { get; set; }

    public string? ImagePath { get; set; }

    public string RoomName { get; set; } = null!;

    public decimal? NumberOfBeds { get; set; }

    public string Status { get; set; } = null!;

    public decimal? HotelId { get; set; }

    public decimal? UserLoginId { get; set; }

    public decimal? Price { get; set; }

    [NotMapped]
    public virtual IFormFile ImageFile { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual ICollection<RoomFacility> RoomFacilities { get; set; } = new List<RoomFacility>();

    public virtual UserLogin? UserLogin { get; set; }
}
