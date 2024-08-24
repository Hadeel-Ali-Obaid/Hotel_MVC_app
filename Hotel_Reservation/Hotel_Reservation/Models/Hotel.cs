using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Reservation.Models;

public partial class Hotel
{
    public decimal Id { get; set; }

    public string HotelName { get; set; } = null!;

    public string? ImagePath { get; set; }

    [NotMapped]
    public virtual IFormFile ImageFile { get; set; }

    public string? Location { get; set; }

    public string Discription { get; set; } = null!;

    public decimal? Rate { get; set; }

    public string? Policies { get; set; }

    public decimal? CityId { get; set; }

    public bool? Pool { get; set; }

    public bool? Hottub { get; set; }

    public bool? Gym { get; set; }

    public bool? Wifi { get; set; }

    public bool? Parking { get; set; }

    public decimal? TotalRooms { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<HotelImage> HotelImages { get; set; } = new List<HotelImage>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
