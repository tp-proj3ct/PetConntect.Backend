namespace PetConnect.Backend.Contracts;

public class PetSitterOutputModel
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public byte[]? ProfilePic { get; set; }
    public string Description { get; set; } = string.Empty;
    public double Rating { get; set; }
    public int ExperienceYears { get; set; }
}
