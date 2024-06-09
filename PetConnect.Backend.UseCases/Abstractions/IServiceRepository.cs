using PetConnect.Backend.Core;

namespace PetConnect.Backend.UseCases.Abstractions;

/// <summary>
/// Интерфейс для доступа к услугам.
/// </summary>
public interface IServiceRepository
{
    /// <summary>
    /// Получить все услуги.
    /// </summary>
    /// <returns> Список услуг. </returns>
    IAsyncEnumerable<Service> GetAll();

    /// <summary>
    /// Получить услугу по индтеификатору пользователя.
    /// </summary>
    /// <param name="userId"> Индетификатор пользователя </param>
    /// <returns> Список услуг. </returns>
    IAsyncEnumerable<Service> GetAllByUserId(long userId);

    /// <summary>
    /// Получить услугу по индтеификатору.
    /// </summary>
    /// <param name="serviceId"> Индетификатор услуги. </param>
    /// <returns> Услуга. </returns>
    Task<Service?> GetById(long serviceId);

    /// <summary>
    /// Добавить услугу.
    /// </summary>
    /// <param name="service"> Услуга. </param>
    Task Add(Service service);

    /// <summary>
    /// Отредактировать услугу.
    /// </summary>
    /// <param name="service"> Услуга.</param>
    Task Update(Service service);

    /// <summary>
    /// Удалить услугу.
    /// </summary>
    /// <param name="service"> Услуга.</param>
    Task Delete(Service service);
}
