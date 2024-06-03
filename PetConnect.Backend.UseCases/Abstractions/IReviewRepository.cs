using PetConnect.Backend.Core;

namespace PetConnect.Backend.UseCases.Abstractions;

public interface IReviewRepository
{
    IAsyncEnumerable<Review> GetAll();
}
