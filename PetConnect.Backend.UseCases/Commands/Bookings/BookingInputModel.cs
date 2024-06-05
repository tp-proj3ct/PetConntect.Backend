namespace PetConnect.Backend.UseCases.Commands.Bookings;

public class BookingInputModel 
{
    public long ServiceId { get; set; }
    public List<long>? PetIds { get; set; }

    public string ServiceAddress { get; set; }
    public string AdditionalRequirements { get; set; }
    public string CustomerComment { get; set; }
}
