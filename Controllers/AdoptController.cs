using System.Security.Claims;
using LoveAtFirstSight.Data;
using LoveAtFirstSight.Models;
using LoveAtFirstSight.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalControllers;


[ApiController]
[Route("api/[controller]")]
public class AdoptController : ControllerBase
{
    private LoveAtFirstSightDbContext _dbContext;

    public AdoptController(LoveAtFirstSightDbContext context)
    {
        _dbContext = context;
    }


    // Get all adoptions
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
        .Adoptions
        .Include(an => an.Animal)
        .Include(an => an.UserProfile)
        .Select(an => new AdoptedDTO
        {
            Id = an.Id,
            Foster = an.Foster,
            AnimalId = an.AnimalId,
            Animal = new AnimalDTO
            {
                Id = an.Animal.Id,
                IsDog = an.Animal.IsDog,
                IsMale = an.Animal.IsMale,
                Name = an.Animal.Name,
                Age = an.Animal.Age,
                Available = an.Animal.Available,
                Fostered = an.Animal.Fostered,
                DateAdded = an.Animal.DateAdded,
                UrlPic = an.Animal.UrlPic,
            },
            UserProfileId = an.UserProfileId,
            UserProfile = new UserProfileDTO
            {
                Id = an.UserProfile.Id,
                FullName = an.UserProfile.FullName,
                Email = an.UserProfile.Email,
                Address = an.UserProfile.Address,
                UserName = an.UserProfile.UserName,
                Employee = an.UserProfile.Employee,
                IdentityUserId = an.UserProfile.IdentityUserId
            },
            TimeOfAdoption = an.TimeOfAdoption
        })
        .ToList());
    }


    // post a new adpotion 
    [HttpPost("addAdoption/{userId}/{animalId}")]
    [Authorize]
    public IActionResult AddAdpotion([FromRoute] string userId, [FromRoute] int animalId)
    {
        int userProfileId = Int32.Parse(userId);

        Adopted adopted = new Adopted
        {
            Foster = false,
            AnimalId = animalId,
            UserProfileId = userProfileId,
            TimeOfAdoption = DateTime.Now
        };

        _dbContext.Adoptions.Add(adopted);
        _dbContext.SaveChanges();

        return NoContent();
    }



    // post a new foster 
    [HttpPost("addFoster/{userId}/{animalId}")]
    [Authorize]
    public IActionResult AddFoster([FromRoute] string userId, [FromRoute] int animalId)
    {
        int userProfileId = Int32.Parse(userId);

        Adopted adopted = new Adopted
        {
            Foster = false,
            AnimalId = animalId,
            UserProfileId = userProfileId,
            TimeOfAdoption = DateTime.Now
        };

        _dbContext.Adoptions.Add(adopted);
        _dbContext.SaveChanges();

        return NoContent();
    }



    [HttpPut("updateUnfosterAdopt/{userId}/{animalId}")]
    [Authorize]
    public IActionResult UpdateUnfoster([FromRoute] int animalId, [FromRoute] int userId)
    {
        // Find adoption by id and userId
        Adopted updatefoster = _dbContext.Adoptions.FirstOrDefault(a => a.AnimalId == animalId && a.UserProfileId == userId);

        // Check if adoption exists
        if (updatefoster == null)
        {
            return NotFound();
        }

            // Change Foster to false
            updatefoster.Foster = false;

            // Save the changes
            _dbContext.SaveChanges();

            return NoContent();

    }



}