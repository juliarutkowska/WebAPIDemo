using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Filters;
using WebAPIDemo.Filters.ExceptionFilters;
using WebAPIDemo.Models;
using WebAPIDemo.Models.Repositories;
using WebAPIDemo.Models.Validations;

namespace WebAPIDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShirtController: ControllerBase
{
    [HttpGet]
    public IActionResult GetShirts()
    {
        return Ok(ShirtRepository.GetShirts());
    }
    
    [HttpGet("{id}")]
    [ShirtValidateShirtIdFilter]
    public IActionResult GetShirtsById(int id)
    {
        return Ok(ShirtRepository.GetShirtById(id));
    }

    [HttpPost]
    [ShirtValidateCreateShirtFilter]
    public IActionResult CreateShirt([FromBody] Shirt shirt)
    {
        ShirtRepository.AddShirt(shirt);

        return CreatedAtAction(nameof(GetShirtsById),
            new { id = shirt.ShirtId },
            shirt);
    }

    [HttpPut("{id}")]
    [ShirtValidateShirtIdFilter]
    [ShirtValidateUpdateShirtFilter]
    [ShirtHandleUpdateExceptionsFilter]
    public IActionResult UpdateShirt(int id, Shirt shirt)
    {
        ShirtRepository.UpdateShirt(shirt);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ShirtValidateShirtIdFilter]
    public IActionResult DeleteShirt(int id)
    {
        var shirt = ShirtRepository.GetShirtById(id);
        ShirtRepository.DeleteShirt(id);
        
        return Ok(shirt);
    }
}