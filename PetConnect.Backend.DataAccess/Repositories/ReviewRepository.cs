using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;

namespace PetConnect.Backend.DataAccess.Repositories;

/// <summary>
/// Реализация <see cref="IReviewRepository"/>.
/// </summary>
public class ReviewRepository(Context context) : IReviewRepository
{
    /// <summary>
    /// Контекст БД.
    /// </summary>
    private readonly Context _context = context ?? throw new ArgumentNullException(nameof(context));

    /// <inheritdoc/>
    public IAsyncEnumerable<Review> GetAll()
    {
        return _context.Reviews.AsAsyncEnumerable();
    }

    /// <inheritdoc/>
    public IAsyncEnumerable<Review> GetAllByPetSitterId(long petSitterId)
    {
        return _context.Reviews.Where(r => r.TargetId == petSitterId).AsAsyncEnumerable();
    }

    /// <inheritdoc/>
    public IAsyncEnumerable<Review> GetAllByPetOwnerId(long petOwnerId)
    {
        return _context.Reviews.Where(r => r.ReviewerId == petOwnerId).AsAsyncEnumerable();
    }

    /// <inheritdoc/>
    public async Task Add(Review review)
    {
        await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();
    }
}
