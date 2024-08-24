using System;
using System.Collections.Generic;

namespace Hotel_Reservation.Models;

public partial class RoomFacility
{
    public decimal Id { get; set; }

    public decimal? RoomId { get; set; }

    public decimal? FacilityId { get; set; }

    public virtual Facility? Facility { get; set; }

    public virtual Room? Room { get; set; }
}
