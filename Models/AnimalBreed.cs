
using System.ComponentModel.DataAnnotations;

namespace LoveAtFirstSight.Models;

public class AnimalBreed
{
    public int Id { get; set; }
    [Required]
    public int AnimalId { get; set; }
    public Animal Animal { get; set; }
    [Required]
    public int BreedId { get; set; }
    public Breed Breed { get; set; }
}




