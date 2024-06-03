using AutoMapper;
using MediatR;
using PetConnect.Backend.Core;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Packages.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Backend.UseCases.Commands.Pets.UpdatePetCommand;


public class DeletePetCommandHandler(IPetRepository petRepository, IMapper mapper) : IRequestHandler<UpdatePetCommand, Result<Unit>>
{
    private readonly IPetRepository _petRepository = petRepository ?? throw new ArgumentNullException(nameof(petRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<Result<Unit>> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
    {
        var pet = await _petRepository.GetById(request.PetId);

        if (pet is null)
        {
            return Result<Unit>.Invalid($"Pet with {request.PetId} is doesn't exist!");
        }

        _mapper.Map(request.Model, pet);

        await _petRepository.Update(pet);

        return Result<Unit>.Empty();
    }
}