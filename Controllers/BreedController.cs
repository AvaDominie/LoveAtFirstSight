using LoveAtFirstSight.Data;
using LoveAtFirstSight.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BreedControllers;


[ApiController]
[Route("api/[controller]")]
public class BreedController : ControllerBase
{
    private LoveAtFirstSightDbContext _dbContext;

    public BreedController(LoveAtFirstSightDbContext context)
    {
        _dbContext = context;
    }


    // Get all breeds
    [HttpGet("dogs")]
    // [Authorize]
    public IActionResult GetDogBreeds()
    {
        return Ok(_dbContext
        .Breeds
        .Where(br => br.IsDog == true)
        .Include(an => an.AnimalBreeds)
        .Select(an => new BreedDTO
        {
            Id = an.Id,
            Name = an.Name,
            IsDog = an.IsDog,
            AnimalBreeds = an.AnimalBreeds.Select(ab => new AnimalBreedDTO
            {
                Id = ab.Id,
                AnimalId = ab.AnimalId,
                BreedId = ab.BreedId
            }).ToList()
        })
        .ToList());
    }




}