namespace PetConnect.Backend.Core;

public class Review
{
    public long Id { get; set; }
    public double Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    
    public PetOwnerProfile Reviewer { get; set; }
    public long ReviewerId { get; set; }

    public PetSitterProfile Target { get; set; }
    public long TargetId { get; set; }
}
