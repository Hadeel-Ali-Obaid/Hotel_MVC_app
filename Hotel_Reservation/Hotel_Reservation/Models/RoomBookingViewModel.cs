using Hotel_Reservation.Models;

public class Booking
{
    public decimal Id { get; set; } // This will be auto-generated if set as an identity column
    public decimal RoomId { get; set; }
    public decimal UserId { get; set; }
    public decimal PaymentCardId { get; set; }
    public DateTime BookingDate { get; set; }

    public virtual Room Room { get; set; }
    public virtual UserLogin User { get; set; }
    public virtual PaymentDatum PaymentCard { get; set; }
}
