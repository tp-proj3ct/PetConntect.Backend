using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.Core;

namespace PetConnect.Backend.Contracts;

public class BookingOutputModel
{
    public long Id { get; set; }

    public DateTime StartedDate { get; set; }
    public DateTime? EndDate { get; set; }

    public Status Status { get; set; }

    public Payment? Payment { get; set; }

    public Service? Service { get; set; }
    public long ServiceId { get; set; }

    public List<Pet>? Pets { get; set; }

    public string ServiceAddress { get; set; } = string.Empty;
    public string AdditionalRequirements { get; set; } = string.Empty;
    public string CustomerComment { get; set; } = string.Empty;
}
