using PetConnect.Backend.Core.Abstractions;

namespace PetConnect.Backend.Core.Users;

/// <summary>
/// Владелец питомцев
/// </summary>
public class PetOwner : User
{
    /// <summary>
    /// Питомцы
    /// </summary>
    public ICollection<Pet>? Pets { get; set; }

    /// <summary>
    /// Оставленные отзывы
    /// </summary>
    public ICollection<Review>? Reviews { get; set; }
}
