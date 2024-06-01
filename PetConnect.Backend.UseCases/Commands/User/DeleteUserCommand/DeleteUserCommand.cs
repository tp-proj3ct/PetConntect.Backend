using MediatR;
using PetConnect.Packages.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Backend.UseCases.Commands.User.DeleteUserCommand;

public sealed record class DeleteUserCommand(long Id) : IRequest<Result<Unit>>;

