using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.Core.Users;

namespace PetConnect.Backend.Core;

public class Booking
{
    public long Id { get; set; }

    public Service? Service { get; set; }
    public long ServiceId { get; set; }

    public PetOwner? Customer { get; set; }
    public long CustomerId { get; set; }

    public List<Pet>? Pets { get; set; }

    public DateTime StartedDate { get; set; } = DateTime.UtcNow;
    public DateTime? EndDate { get; set; }

    public Status Status { get; set; }

    public string ServiceAddress { get; set; } = string.Empty;
    public string AdditionalRequirements { get; set; } = string.Empty;
    public string CustomerComment { get; set; } = string.Empty;

    public Payment? Payment { get; set; }
}

