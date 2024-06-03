using MediatR;
using PetConnect.Packages.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Backend.UseCases.Commands.Services.UpdateServiceCommand;

public record UpdateServiceCommand(long ServiceId, ServiceInputModel Model) : IRequest<Result<Unit>>;