using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PetConnect.Backend.Service.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        throw new NotImplementedException();
    }

    [Authorize(Roles = "PetSitter, PetOwner")]
    [HttpPut("profile")]
    public async Task<IActionResult> EditProfile()
    {
        throw new NotImplementedException();
    }

    [HttpPost("profile")]
    public async Task<IActionResult> CreateProfile()
    {
        throw new NotImplementedException();
    }

    [HttpDelete("")]
    public async Task<IActionResult> DeleteUser()
    {
        throw new NotImplementedException();
    }
}
 