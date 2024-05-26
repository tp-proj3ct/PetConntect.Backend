namespace PetConnect.Backend.Core;

public class Service
{
    public long Id { get; set; }

    public PetSitterProfile PetSitterProfile { get; set;}
    public long PetSitterProfileId { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
}
