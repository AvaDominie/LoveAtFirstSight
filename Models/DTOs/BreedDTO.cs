
using System.ComponentModel.DataAnnotations;

namespace LoveAtFirstSight.Models.DTOs;

public class BreedDTO
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public List<AnimalBreedDTO> AnimalBreeds { get; set; }
}