using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.Core.Users;

namespace PetConnect.Backend.Core;

public class Pet
{
    public long Id { get; set; }

    public long PetOwnerId { get; set; }

    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public int Weight { get; set; }

    public Gender Gender { get; set; }

    public string Behavior { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Breed { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string MedicalInfo { get; set; } = string.Empty;

    public byte[]? Picture { get; set; }
}
