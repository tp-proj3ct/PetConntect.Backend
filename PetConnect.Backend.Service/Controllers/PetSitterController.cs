using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetConnect.Backend.Core;

namespace PetConnect.Backend.Service.Controllers;

using Service = Core.Service;

[Route("api/pet-sitter")]
[AllowAnonymous]
[ApiController]
public class PetSitterController : ControllerBase
{
    [HttpGet("reviews")]
    public IEnumerable<Review> GetAllPetSitterReviews()
    {
        return new List<Review>();
    }

    //[HttpGet("/services")]
    //public IEnumerable<Service> GetAllPetSitterServices()
    //{
    //    return new List<Service>();
    //}
}
