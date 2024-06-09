using PetConnect.Backend.Core;

namespace PetConnect.Backend.UseCases.Abstractions;

/// <summary>
/// Интерфейс для доступа к отзывам.
/// </summary>
public interface IReviewRepository
{
    /// <summary>
    /// Получить все отзывы.
    /// </summary>
    /// <returns> Список отзывов. </returns>
    IAsyncEnumerable<Review> GetAll();

    /// <summary>
    /// Получить все отзывы владельца питомцев.
    /// </summary>
    /// <param name="petOwnerId"> Индетификатор владельца питомцев.</param>
    /// <returns> Список отзывов. </returns>
    IAsyncEnumerable<Review> GetAllByPetOwnerId(long petOwnerId);

    /// <summary>
    /// Получить все отзывы сиделки.
    /// </summary>
    /// <param name="petSitterId"> Индетификатор сиделки. </param>
    /// <returns> Список отзывов. </returns>
    IAsyncEnumerable<Review> GetAllByPetSitterId(long petSitterId);

    /// <summary>
    /// Добавить отзыв.
    /// </summary>
    /// <param name="review"> Отзыв. </param>
    Task Add(Review review);

}
