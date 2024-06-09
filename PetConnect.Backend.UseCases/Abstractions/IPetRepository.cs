using PetConnect.Backend.Core;

namespace PetConnect.Backend.UseCases.Abstractions;

/// <summary>
/// Интерфейс для доступа к питомцам.
/// </summary>
public interface IPetRepository
{
    /// <summary>
    /// Получить всех питомцев.
    /// </summary>
    /// <returns> Список питомцев. </returns>
    IAsyncEnumerable<Pet> GetAll();

    /// <summary>
    /// Получить всех питомцев пользователя.
    /// </summary>
    /// <param name="userId"> Индетификатор пользователя </param>
    /// <returns> Список питомцев. </returns>
    IAsyncEnumerable<Pet> GetAllByUserId(long userId);

    /// <summary>
    /// Получить питомца по индетификатору.
    /// </summary>
    /// <param name="petId"> Индетификатор питомца. </param>
    /// <returns> Питомец. </returns>
    Task<Pet?> GetById(long petId);

    /// <summary>
    /// Добавить питомца.
    /// </summary>
    /// <param name="pet"> Питомец. </param>
    Task Add(Pet pet);

    /// <summary>
    /// Отредактировать питомца.
    /// </summary>
    /// <param name="pet"> Питомец. </param>
    Task Update(Pet pet);

    /// <summary>
    /// Удалить питомца.
    /// </summary>
    /// <param name="pet"> Питомец. </param>
    Task Delete(Pet pet);
}
