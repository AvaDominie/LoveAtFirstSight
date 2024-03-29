using LoveAtFirstSight.Data;
using LoveAtFirstSight.Models;
using LoveAtFirstSight.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UserProfileControllers;


[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private LoveAtFirstSightDbContext _dbContext;

    public UserProfileController(LoveAtFirstSightDbContext context)
    {
        _dbContext = context;
    }


    // Get all users
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
        .UserProfiles
        .Include(an => an.Adoptions)
            .ThenInclude(an => an.Animal)
        .Select(an => new UserProfileDTO
        {
            Id = an.Id,
            FullName = an.FullName,
            Email = an.Email,
            Address = an.Address,
            UserName = an.UserName,
            Employee = an.Employee,
            IdentityUserId = an.IdentityUserId,
            Adoptions = an.Adoptions.Select(ad => new AdoptedDTO
            {
                Id = ad.Id,
                Foster = ad.Foster,
                AnimalId = ad.AnimalId,
                Animal = new AnimalDTO
                {
                    Id = ad.Animal.Id,
                    IsDog = ad.Animal.IsDog,
                    IsMale = ad.Animal.IsMale,
                    Name = ad.Animal.Name,
                    Age = ad.Animal.Age,
                    Available = ad.Animal.Available,
                    Fostered = ad.Animal.Fostered,
                    DateAdded = ad.Animal.DateAdded,
                    UrlPic = ad.Animal.UrlPic
                },
                UserProfileId = ad.UserProfileId,
                TimeOfAdoption = ad.TimeOfAdoption
            }).ToList()
        })
        .ToList());
    }


    // get user by Id
    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetUserById(int id)
    {
        UserProfile userProfile = _dbContext
            .UserProfiles
            .Include(an => an.Adoptions)
                .ThenInclude(an => an.Animal)
            .SingleOrDefault(an => an.Id == id);

        if (userProfile == null)
        {
            return NotFound();
        }

        return Ok(userProfile);
    }


    // update users profile 
    [HttpPut("{id}")]
    [Authorize]
    public IActionResult EditUserProfile(int id, [FromBody] UpdateUserProfileDTO updateUserProfile)
    {
        // find the user
        UserProfile userProfiletoUpdate = _dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .SingleOrDefault(up => up.Id == id);

        // check if user exists
        if (userProfiletoUpdate == null)
        {
            return NotFound();
        }
        else if (id != userProfiletoUpdate.Id)
        {
            return BadRequest();
        }



        // update user
        userProfiletoUpdate.FullName = updateUserProfile.FullName;
        userProfiletoUpdate.Email = updateUserProfile.Email;
        userProfiletoUpdate.Address = updateUserProfile.Address;
        userProfiletoUpdate.UserName = updateUserProfile.UserName;

        // save
        _dbContext.SaveChanges();

        return NoContent();

    }





}