using LoveAtFirstSight.Data;
using LoveAtFirstSight.Models;
using LoveAtFirstSight.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalControllers;


[ApiController]
[Route("api/[controller]")]
public class AnimalController : ControllerBase
{
    private LoveAtFirstSightDbContext _dbContext;

    public AnimalController(LoveAtFirstSightDbContext context)
    {
        _dbContext = context;
    }


    // Get all animals
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
        .Animals
        .Include(an => an.Adoptions)
        .Include(an => an.AnimalBreeds)
        .Select(an => new AnimalDTO
        {
            Id = an.Id,
            IsDog = an.IsDog,
            IsMale = an.IsMale,
            Name = an.Name,
            Age = an.Age,
            Available = an.Available,
            Fostered = an.Fostered,
            DateAdded = an.DateAdded,
            UrlPic = an.UrlPic,
            AnimalBreeds = an.AnimalBreeds.Select(ab => new AnimalBreedDTO
            {
                Id = ab.Id,
                AnimalId = ab.AnimalId,
                BreedId = ab.BreedId
            }).ToList(),
            Adoptions = an.Adoptions.Select(ad => new AdoptedDTO
            {
                Id = ad.Id,
                Foster = ad.Foster,
                AnimalId = ad.AnimalId,
                UserProfileId = ad.UserProfileId,
                TimeOfAdoption = ad.TimeOfAdoption
            }).ToList()
        })
        .ToList());
    }


    // get all avaliable dogs
    [HttpGet("allDogs")]
    [Authorize]
    public IActionResult GetDogs()
    {
        return Ok(_dbContext
        .Animals
        .Where(an => an.Available == true)
        .Where(an => an.IsDog == true)
        .Include(an => an.Adoptions)
        .Include(an => an.AnimalBreeds)
        .Select(an => new AnimalDTO
        {
            Id = an.Id,
            IsDog = an.IsDog,
            IsMale = an.IsMale,
            Name = an.Name,
            Age = an.Age,
            Available = an.Available,
            Fostered = an.Fostered,
            DateAdded = an.DateAdded,
            UrlPic = an.UrlPic,
            AnimalBreeds = an.AnimalBreeds.Select(ab => new AnimalBreedDTO
            {
                Id = ab.Id,
                AnimalId = ab.AnimalId,
                BreedId = ab.BreedId
            }).ToList(),
            Adoptions = an.Adoptions.Select(ad => new AdoptedDTO
            {
                Id = ad.Id,
                Foster = ad.Foster,
                AnimalId = ad.AnimalId,
                UserProfileId = ad.UserProfileId,
                TimeOfAdoption = ad.TimeOfAdoption
            }).ToList()
        })
        .ToList());
    }



    // get all avaliable cats
    [HttpGet("allCats")]
    [Authorize]
    public IActionResult GetCats()
    {
        return Ok(_dbContext
        .Animals
        .Where(an => an.Available == true)
        .Where(an => an.IsDog == false)
        .Include(an => an.Adoptions)
        .Include(an => an.AnimalBreeds)
        .Select(an => new AnimalDTO
        {
            Id = an.Id,
            IsDog = an.IsDog,
            IsMale = an.IsMale,
            Name = an.Name,
            Age = an.Age,
            Available = an.Available,
            Fostered = an.Fostered,
            DateAdded = an.DateAdded,
            UrlPic = an.UrlPic,
            AnimalBreeds = an.AnimalBreeds.Select(ab => new AnimalBreedDTO
            {
                Id = ab.Id,
                AnimalId = ab.AnimalId,
                BreedId = ab.BreedId
            }).ToList(),
            Adoptions = an.Adoptions.Select(ad => new AdoptedDTO
            {
                Id = ad.Id,
                Foster = ad.Foster,
                AnimalId = ad.AnimalId,
                UserProfileId = ad.UserProfileId,
                TimeOfAdoption = ad.TimeOfAdoption
            }).ToList()
        })
        .ToList());
    }




    // get all fostered dogs
    [HttpGet("allFosteredDogs")]
    [Authorize]
    public IActionResult GetFosteredDogs()
    {
        return Ok(_dbContext
        .Animals
        .Where(an => an.Available == true)
        .Where(an => an.IsDog == true)
        .Where(an => an.Fostered == true)
        .Include(an => an.Adoptions)
        .Include(an => an.AnimalBreeds)
        .Select(an => new AnimalDTO
        {
            Id = an.Id,
            IsDog = an.IsDog,
            IsMale = an.IsMale,
            Name = an.Name,
            Age = an.Age,
            Available = an.Available,
            Fostered = an.Fostered,
            DateAdded = an.DateAdded,
            UrlPic = an.UrlPic,
            AnimalBreeds = an.AnimalBreeds.Select(ab => new AnimalBreedDTO
            {
                Id = ab.Id,
                AnimalId = ab.AnimalId,
                BreedId = ab.BreedId
            }).ToList(),
            Adoptions = an.Adoptions.Select(ad => new AdoptedDTO
            {
                Id = ad.Id,
                Foster = ad.Foster,
                AnimalId = ad.AnimalId,
                UserProfileId = ad.UserProfileId,
                TimeOfAdoption = ad.TimeOfAdoption
            }).ToList()
        })
        .ToList());
    }


    // get all fostered cats
    [HttpGet("allFosteredCats")]
    [Authorize]
    public IActionResult GetFosteredCats()
    {
        return Ok(_dbContext
        .Animals
        .Where(an => an.Available == true)
        .Where(an => an.IsDog == false)
        .Where(an => an.Fostered == true)
        .Include(an => an.Adoptions)
        .Include(an => an.AnimalBreeds)
        .Select(an => new AnimalDTO
        {
            Id = an.Id,
            IsDog = an.IsDog,
            IsMale = an.IsMale,
            Name = an.Name,
            Age = an.Age,
            Available = an.Available,
            Fostered = an.Fostered,
            DateAdded = an.DateAdded,
            UrlPic = an.UrlPic,
            AnimalBreeds = an.AnimalBreeds.Select(ab => new AnimalBreedDTO
            {
                Id = ab.Id,
                AnimalId = ab.AnimalId,
                BreedId = ab.BreedId
            }).ToList(),
            Adoptions = an.Adoptions.Select(ad => new AdoptedDTO
            {
                Id = ad.Id,
                Foster = ad.Foster,
                AnimalId = ad.AnimalId,
                UserProfileId = ad.UserProfileId,
                TimeOfAdoption = ad.TimeOfAdoption
            }).ToList()
        })
        .ToList());
    }


    // get all dogs for a breed
    [HttpGet("allDogsBreed/{breedName}")]
    [Authorize]
    public IActionResult GetDogsBreed(string breedName)
    {
        return Ok(_dbContext
        .Animals
        .Where(an => an.AnimalBreeds.Any(ab => ab.Breed.Name == breedName))
        .Where(an => an.Available == true)
        .Where(an => an.IsDog == true)
        .Include(an => an.Adoptions)
        .Include(an => an.AnimalBreeds)
        .Select(an => new AnimalDTO
        {
            Id = an.Id,
            IsDog = an.IsDog,
            IsMale = an.IsMale,
            Name = an.Name,
            Age = an.Age,
            Available = an.Available,
            Fostered = an.Fostered,
            DateAdded = an.DateAdded,
            UrlPic = an.UrlPic,
            AnimalBreeds = an.AnimalBreeds.Select(ab => new AnimalBreedDTO
            {
                Id = ab.Id,
                AnimalId = ab.AnimalId,
                BreedId = ab.BreedId
            }).ToList(),
            Adoptions = an.Adoptions.Select(ad => new AdoptedDTO
            {
                Id = ad.Id,
                Foster = ad.Foster,
                AnimalId = ad.AnimalId,
                UserProfileId = ad.UserProfileId,
                TimeOfAdoption = ad.TimeOfAdoption
            }).ToList()
        })
        .ToList());
    }

    // get all fostered dogs by breed
    [HttpGet("allFosteredDogsByBreed/{breedName}")]
    [Authorize]
    public IActionResult GetFosteredDogsByBreed(string breedName)
    {
        return Ok(_dbContext
        .Animals
        .Where(an => an.AnimalBreeds.Any(ab => ab.Breed.Name == breedName))
        .Where(an => an.Available == true)
        .Where(an => an.IsDog == true)
        .Where(an => an.Fostered == true)
        .Include(an => an.Adoptions)
        .Include(an => an.AnimalBreeds)
        .Select(an => new AnimalDTO
        {
            Id = an.Id,
            IsDog = an.IsDog,
            IsMale = an.IsMale,
            Name = an.Name,
            Age = an.Age,
            Available = an.Available,
            Fostered = an.Fostered,
            DateAdded = an.DateAdded,
            UrlPic = an.UrlPic,
            AnimalBreeds = an.AnimalBreeds.Select(ab => new AnimalBreedDTO
            {
                Id = ab.Id,
                AnimalId = ab.AnimalId,
                BreedId = ab.BreedId
            }).ToList(),
            Adoptions = an.Adoptions.Select(ad => new AdoptedDTO
            {
                Id = ad.Id,
                Foster = ad.Foster,
                AnimalId = ad.AnimalId,
                UserProfileId = ad.UserProfileId,
                TimeOfAdoption = ad.TimeOfAdoption
            }).ToList()
        })
        .ToList());
    }

    // get all cats for a breed
    [HttpGet("allCatsBreed/{breedName}")]
    [Authorize]
    public IActionResult GetCatsBreed(string breedName)
    {
        return Ok(_dbContext
        .Animals
        .Where(an => an.AnimalBreeds.Any(ab => ab.Breed.Name == breedName))
        .Where(an => an.Available == true)
        .Where(an => an.IsDog == false)
        .Include(an => an.Adoptions)
        .Include(an => an.AnimalBreeds)
        .Select(an => new AnimalDTO
        {
            Id = an.Id,
            IsDog = an.IsDog,
            IsMale = an.IsMale,
            Name = an.Name,
            Age = an.Age,
            Available = an.Available,
            Fostered = an.Fostered,
            DateAdded = an.DateAdded,
            UrlPic = an.UrlPic,
            AnimalBreeds = an.AnimalBreeds.Select(ab => new AnimalBreedDTO
            {
                Id = ab.Id,
                AnimalId = ab.AnimalId,
                BreedId = ab.BreedId
            }).ToList(),
            Adoptions = an.Adoptions.Select(ad => new AdoptedDTO
            {
                Id = ad.Id,
                Foster = ad.Foster,
                AnimalId = ad.AnimalId,
                UserProfileId = ad.UserProfileId,
                TimeOfAdoption = ad.TimeOfAdoption
            }).ToList()
        })
        .ToList());
    }

    // get all fostered cats by breed
    [HttpGet("allFosteredCatsByBreed/{breedName}")]
    [Authorize]
    public IActionResult GetFosteredCatsByBreed(string breedName)
    {
        return Ok(_dbContext
        .Animals
        .Where(an => an.AnimalBreeds.Any(ab => ab.Breed.Name == breedName))
        .Where(an => an.Available == true)
        .Where(an => an.IsDog == false)
        .Where(an => an.Fostered == true)
        .Include(an => an.Adoptions)
        .Include(an => an.AnimalBreeds)
        .Select(an => new AnimalDTO
        {
            Id = an.Id,
            IsDog = an.IsDog,
            IsMale = an.IsMale,
            Name = an.Name,
            Age = an.Age,
            Available = an.Available,
            Fostered = an.Fostered,
            DateAdded = an.DateAdded,
            UrlPic = an.UrlPic,
            AnimalBreeds = an.AnimalBreeds.Select(ab => new AnimalBreedDTO
            {
                Id = ab.Id,
                AnimalId = ab.AnimalId,
                BreedId = ab.BreedId
            }).ToList(),
            Adoptions = an.Adoptions.Select(ad => new AdoptedDTO
            {
                Id = ad.Id,
                Foster = ad.Foster,
                AnimalId = ad.AnimalId,
                UserProfileId = ad.UserProfileId,
                TimeOfAdoption = ad.TimeOfAdoption
            }).ToList()
        })
        .ToList());
    }

    // get animal by Id
    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        Animal animal = _dbContext
            .Animals
            .Include(an => an.Adoptions)
            .Include(an => an.AnimalBreeds)
                .ThenInclude(an => an.Breed)
            .SingleOrDefault(an => an.Id == id);

        if (animal == null)
        {
            return NotFound();
        }

        return Ok(animal);
    }



    // update animals availablity when it's adopted
    [HttpPut("updateAvailability/{animalId}")]
    [Authorize]
    public IActionResult UpdateAnimalAvailability(int animalId)
    {
        // find animal
        Animal animal = _dbContext.Animals.Find(animalId);

        // check if animal exists
        if (animal == null)
        {
            return NotFound();
        }

        // check if animal has been adopted
        var adoption = _dbContext.Adoptions.Any(a => a.AnimalId == animalId);
        if (adoption)
        {
            // update the animal
            animal.Available = false;

            // save the changes
            _dbContext.SaveChanges();
        }

        return NoContent();
    }

    // update animals foster when it's fostered
    [HttpPut("updateFoster/{animalId}")]
    [Authorize]
    public IActionResult UpdateAnimalFostered(int animalId)
    {
        // find animal
        Animal animal = _dbContext.Animals.Find(animalId);

        // check if animal exists
        if (animal == null)
        {
            return NotFound();
        }

        // check if animal has been fostered
        var fostered = _dbContext.Adoptions.Any(a => a.AnimalId == animalId);
        if (fostered)
        {
            // update the animal
            animal.Fostered = true;

            // save the changes
            _dbContext.SaveChanges();
        }

        return NoContent();
    }





}
