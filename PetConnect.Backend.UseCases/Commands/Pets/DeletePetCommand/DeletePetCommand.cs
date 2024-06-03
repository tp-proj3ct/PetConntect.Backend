using MediatR;
using PetConnect.Packages.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Backend.UseCases.Commands.Pets.DeletePetCommand;

public record DeletePetCommand(long PetId) : IRequest<Result<Unit>>;