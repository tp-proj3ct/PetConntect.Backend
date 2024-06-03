using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetConnect.Backend.Core;

namespace PetConnect.Backend.Service.Controllers;

using Service = Core.Service;

[Route("api/pet-sitters")]
[AllowAnonymous]
[ApiController]
public class PetSittersController : ControllerBase
{
    /// <summary>
    /// Получить все отзывы конкретного PetSitter
    /// </summary>
    /// <returns> Массив из питомцев </returns>
    /// <response code="200"> Отзывы найдены.</response>
    /// <response code="400">Некорректный запрос.</response>
    [HttpGet("{id}/reviews")]
    [ProducesResponseType(typeof(IAsyncEnumerable<Review>), 200)]
    [ProducesResponseType(400)]
    public IEnumerable<Review> GetAllPetSitterReviews(long id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Получить все услуги конкретного PetSitter
    /// </summary>
    /// <returns> Массив из питомцев </returns>
    /// <response code="200"> Услуги найдены. </response>
    /// <response code="400">Некорректный запрос.</response>
    [HttpGet("{id}/services")]
    [ProducesResponseType(typeof(IAsyncEnumerable<Service>), 200)]
    [ProducesResponseType(400)]
    public IEnumerable<Review> GetAllPetSitterServices(long id)
    {
        throw new NotImplementedException();
    }
}
