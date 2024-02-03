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

    // soft delete foster
    [HttpPut("updateUnfosterAdopt/{animalId}")]
    [Authorize]
    public IActionResult DeleteAnimalFostered(int animalId)
    {
        // find animal
        Animal animal = _dbContext.Animals.Find(animalId);

        // check if animal exists
        if (animal == null)
        {
            return NotFound();
        }

        // update the animal
        animal.Fostered = false;

        // save the changes
        _dbContext.SaveChanges();

        return NoContent();
    }



    // employee add animal
    [HttpPost("addAnimal")]
    [Authorize(Roles = "Employee")]
    public IActionResult AddAnimal(AnimalDTO animalDTO)
    {
        Animal animal = new Animal
        {
            IsDog = animalDTO.IsDog,
            IsMale = animalDTO.IsMale,
            Name = animalDTO.Name,
            Age = animalDTO.Age,
            Available = true,
            Fostered = false,
            DateAdded = DateTime.Now,
            UrlPic = animalDTO.UrlPic
        };


        // Add the AnimalBreed entities to the Animal's AnimalBreeds list

        _dbContext.Animals.Add(animal);
        _dbContext.SaveChanges();

        if (animalDTO.AnimalBreeds != null)
        {
            foreach (var animalBreedDTO in animalDTO.AnimalBreeds)
            {
                AnimalBreed animalBreed = new AnimalBreed
                {
                    AnimalId = animal.Id,
                    BreedId = animalBreedDTO.BreedId
                };
                _dbContext.AnimalBreeds.Add(animalBreed);

            }
        }

        _dbContext.SaveChanges();

        return Created($"/api/animal/{animal.Id}", animal);
    }


    // employee update animal
    [HttpPut("updateAnimal/{animalId}")]
    [Authorize(Roles = "Employee")]
    public IActionResult UpdateAnimal(int animalId, [FromBody] AnimalDTO updateAnimal)
    {
        Animal animaltoUpdate = _dbContext.Animals
            .Include(a => a.AnimalBreeds)
            .SingleOrDefault(up => up.Id == animalId);

        // check if user exists
        if (animaltoUpdate == null)
        {
            return NotFound();
        }
        else if (animalId != animaltoUpdate.Id)
        {
            return BadRequest();
        }

        // Remove existing AnimalBreeds
        _dbContext.AnimalBreeds.RemoveRange(animaltoUpdate.AnimalBreeds);

        // Update animal
        animaltoUpdate.IsDog = updateAnimal.IsDog;
        animaltoUpdate.IsMale = updateAnimal.IsMale;
        animaltoUpdate.Name = updateAnimal.Name;
        animaltoUpdate.Age = updateAnimal.Age;
        animaltoUpdate.UrlPic = updateAnimal.UrlPic;

        // Add new AnimalBreeds
        if (updateAnimal.AnimalBreeds != null)
        {
            foreach (var animalBreedDTO in updateAnimal.AnimalBreeds)
            {
                AnimalBreed animalBreed = new AnimalBreed
                {
                    AnimalId = animaltoUpdate.Id,
                    BreedId = animalBreedDTO.BreedId
                };
                _dbContext.AnimalBreeds.Add(animalBreed);
            }
        }

        _dbContext.SaveChanges();

        return NoContent();
    }



    // delete animal
    [HttpDelete("deleteAnimal/{animalId}")]
    [Authorize(Roles = "Employee")]
    public IActionResult DeleteAnimal([FromRoute] int animalId)
    {
        Animal animal = _dbContext.Animals
            .Include(a => a.AnimalBreeds)
            .FirstOrDefault(a => a.Id == animalId);

        // Check if adoption exists
        if (animal == null)
        {
            return NotFound();
        }

        // Remove the associated AnimalBreeds
        _dbContext.AnimalBreeds.RemoveRange(animal.AnimalBreeds);

        // Remove the animal record
        _dbContext.Animals.Remove(animal);
        _dbContext.SaveChanges();

        return NoContent();

    }


}

// swagger add dog outline 
// {
//   "isDog": true,
//   "isMale": true,
//   "name": "Red",
//   "age": 2,
//   "available": true,
//   "fostered": true,
//   "dateAdded": "2024-02-02T16:34:38.895Z",
//   "urlPic": "https://i.pinimg.com/564x/41/9a/7d/419a7d66b4805f1fde315f494d59776d.jpg",
//   "animalBreeds": [
//     {
//      "breedId": 1

//     }
//   ]
// }
