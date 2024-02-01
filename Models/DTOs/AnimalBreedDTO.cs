
using System.ComponentModel.DataAnnotations;

namespace LoveAtFirstSight.Models.DTOs;

public class AnimalBreedDTO
{
    public int Id { get; set; }
    [Required]
    public int AnimalId { get; set; }
    public AnimalDTO? Animal { get; set; }
    [Required]
    public int BreedId { get; set; }
    public BreedDTO? Breed { get; set; }
}

