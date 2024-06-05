using PetConnect.Backend.Core;

namespace PetConnect.Backend.UseCases.Abstractions;

public interface IReviewRepository
{
    IAsyncEnumerable<Review> GetAll();

    IAsyncEnumerable<Review> GetAllByPetOwnerId(long petOwnerId);

    IAsyncEnumerable<Review> GetAllByPetSitterId(long petSitterId);

    Task Add(Review review);

}
