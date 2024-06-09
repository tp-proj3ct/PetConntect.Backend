using PetConnect.Backend.Core.Users;

namespace PetConnect.Backend.UseCases.Abstractions;

/// <summary>
/// Интерфейс для доступа к сиделкам.
/// </summary>
public interface IPetSitterRepository
{
    /// <summary>
    /// Получить всех сиделок.
    /// </summary>
    /// <returns> Список сиделок. </returns>
    public IEnumerable <PetSitter> GetAll();

    /// <summary>
    /// Получить сиделку по индетификатору.
    /// </summary>
    /// <param name="id"> Индетификатор сиделки. </param>
    /// <returns> Сиделка. </returns>
    public Task<PetSitter?> GetById(long id);
}
