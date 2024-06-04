using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;


namespace PetConnect.Backend.DataAccess.Repositories;

public class ReviewRepository(Context context) : IReviewRepository
{
    private readonly Context _context = context ?? throw new ArgumentNullException(nameof(context));

    public IAsyncEnumerable<Review> GetAll()
    {
        return _context.Reviews.AsAsyncEnumerable();
    }

    public IAsyncEnumerable<Review> GetAllByPetSitterId(long petSitterId)
    {
        return _context.Reviews.Where(r => r.TargetId == petSitterId).AsAsyncEnumerable();
    }

    public IAsyncEnumerable<Review> GetAllByPetOwnerId(long petOwnerId)
    {
        return _context.Reviews.Where(r => r.ReviewerId == petOwnerId).AsAsyncEnumerable();
    }

}
