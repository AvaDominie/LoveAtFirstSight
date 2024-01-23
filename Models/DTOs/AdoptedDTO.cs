
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
    public int UserId { get; set; }
    public UserDTO User { get; set; }
    [Required]
    public DateTime TimeOfAdoption { get; set; }
}