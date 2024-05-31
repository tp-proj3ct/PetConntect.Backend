using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PetConnect.Backend.Service.Controllers;

[Route("api/pets")]
[Authorize(Roles = "PetOwner")]
public class PetsController : ControllerBase
{
    [HttpGet("/")]
    public async Task<IActionResult> GetAllUserPets()
    {
        throw new NotImplementedException();
    }

    [HttpPost("/")]
    public async Task<IActionResult> CreateUserPet()
    {
        throw new NotImplementedException();
    }

    [HttpGet("/{id}")]
    public async Task<IActionResult> GetPetById(long id)
    {
        throw new NotImplementedException();
    }

    [HttpPut("/{id}")]
    public async Task<IActionResult> EditPetById(long id)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("/{id}")]
    public async Task<IActionResult> DeletePetById(long id)
    {
        throw new NotImplementedException();
    }
}
