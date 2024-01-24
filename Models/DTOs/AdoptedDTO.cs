
using System.ComponentModel.DataAnnotations;

namespace LoveAtFirstSight.Models.DTOs;

public class AdoptedDTO
{
    public int Id { get; set; }
    [Required]
    public bool Foster { get; set; }
    [Required]
    public int AnimalId { get; set; }
    public AnimalDTO Animal { get; set; }
    [Required]
    public int UserProfileId { get; set; }
    public UserProfileDTO UserProfile { get; set; }
    public DateTime TimeOfAdoption { get; set; }
}