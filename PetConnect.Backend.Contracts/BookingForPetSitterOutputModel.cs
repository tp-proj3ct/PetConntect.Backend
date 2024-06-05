using PetConnect.Backend.Core.Users;

namespace PetConnect.Backend.Contracts;

public class BookingForPetSitterOutputModel : BookingOutputModel
{

    public PetOwner? Customer { get; set; }
    public long CustomerId { get; set; }
}
