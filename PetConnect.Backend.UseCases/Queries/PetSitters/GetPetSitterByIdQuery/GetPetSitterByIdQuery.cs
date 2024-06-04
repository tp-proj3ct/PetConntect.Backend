using MediatR;
using PetConnect.Backend.Contracts;
using PetConnect.Packages.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Backend.UseCases.Queries.PetSitters.GetPetSitterByIdQuery;

public record GetPetSitterByIdQuery(long PetSitterId) : IRequest<Result<PetSitterOutputModel>>;
