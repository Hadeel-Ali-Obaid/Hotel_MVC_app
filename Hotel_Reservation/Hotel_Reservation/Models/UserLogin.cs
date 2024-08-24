using System;
using System.Collections.Generic;

namespace Hotel_Reservation.Models;

public partial class UserLogin
{
    public decimal Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public decimal? RoleId { get; set; }

    public decimal? UserProfileId { get; set; }

    public decimal? PaymentId { get; set; }

    public virtual ICollection<ContactU> ContactUs { get; set; } = new List<ContactU>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual PaymentDatum? Payment { get; set; }

    public virtual UserRole? Role { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<Testimonial> Testimonials { get; set; } = new List<Testimonial>();

    public virtual UserProfile? UserProfile { get; set; }
}
