using MediatR;
using PetConnect.Backend.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Backend.UseCases.Queries.Reviews.GetAllReviewsByPetSitterIdQuery;

public record class GetAllReviewsByPetSitterIdQuery(long PetSitterId) : IStreamRequest<ReviewOutputModel>;

