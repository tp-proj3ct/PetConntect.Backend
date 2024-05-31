using PetConnect.Backend.Core.Users;

namespace PetConnect.Backend.Core;

public class Service
{
    public long Id { get; set; }
    public long PetSitterId { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
}
