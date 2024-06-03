namespace PetConnect.Backend.Contracts;

public class PetOutputModel
{
    public long Id { get; set; }

    public string Name { get; set; }
    public int Age { get; set; }
    public int Weight { get; set; }

    public string Gender { get; set; }

    public string Behavior { get; set; } 
    public string Type { get; set; }
    public string Breed { get; set; }
    public string Description { get; set; }
    public string MedicalInfo {  get; set; }

}
