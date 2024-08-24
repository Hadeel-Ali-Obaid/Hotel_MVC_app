using System;
using System.Collections.Generic;

namespace Hotel_Reservation.Models;

public partial class Facility
{
    public decimal Id { get; set; }

    public string FacilityName { get; set; } = null!;

    public virtual ICollection<RoomFacility> RoomFacilities { get; set; } = new List<RoomFacility>();
}
