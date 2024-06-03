using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Backend.DataAccess.Repositories;

public class ReviewRepository(Context context) : IReviewRepository
{
    private readonly Context _context = context ?? throw new ArgumentNullException(nameof(context));

    public IAsyncEnumerable<Review> GetAll()
    {
        return _context.Reviews.AsAsyncEnumerable();
    }
}
