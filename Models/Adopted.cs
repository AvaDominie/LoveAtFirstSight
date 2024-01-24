
using System.ComponentModel.DataAnnotations;

namespace LoveAtFirstSight.Models;

public class Adopted
{
    public int Id { get; set; }
    [Required]
    public bool Foster { get; set; }
    [Required]
    public int AnimalId { get; set; }
    public Animal Animal { get; set; }
    [Required]
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public DateTime TimeOfAdoption { get; set; }
}