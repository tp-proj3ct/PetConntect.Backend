using PetConnect.Backend.Core;

namespace PetConnect.Backend.UseCases.Abstractions;

public interface IServiceRepository
{
    IAsyncEnumerable<Service> GetAll();

    IAsyncEnumerable<Service> GetAllByUserId(long userId);

    Task<Service?> GetById(long serviceId);

    Task Add(Service service);

    Task Update(Service service);

    Task Delete(Service service);
}
