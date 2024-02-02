using LoveAtFirstSight.Data;
using LoveAtFirstSight.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
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

    // get all breeds
    [HttpGet()]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
        .Breeds
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



    // Get all dog breeds
    [HttpGet("dogs")]
    [Authorize]
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

    // Get all cat breeds
    [HttpGet("cats")]
    [Authorize]
    public IActionResult GetCatBreeds()
    {
        return Ok(_dbContext
        .Breeds
        .Where(br => br.IsDog == false)
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