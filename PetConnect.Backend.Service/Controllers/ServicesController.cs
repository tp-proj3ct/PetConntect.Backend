using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PetConnect.Backend.Service.Controllers;

[Authorize(Roles = "PetSitter")]
[Route("api/services")]
[ApiController]
public class ServicesController : ControllerBase
{
}
