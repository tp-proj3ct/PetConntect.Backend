namespace PetConnect.Backend.Core;

public class Payment
{
    public long Id { get; set; }
    public double Amount { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.Now;

    public long BookingId { get; set; }
    public Booking? Booking { get; set; }
}
