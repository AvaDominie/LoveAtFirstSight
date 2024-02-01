using System.ComponentModel.DataAnnotations;

namespace LoveAtFirstSight.Models.DTOs;

public class AnimalDTO
{
    public int Id { get; set; }
    [Required]
    public bool IsDog { get; set; }
    [Required]
    public bool IsMale { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public bool Available { get; set; }
    [Required]
    public bool Fostered { get; set; }
    [Required]
    public DateTime DateAdded { get; set; }
    [Required]
    public string UrlPic { get; set; }
    public List<AnimalBreedDTO>? AnimalBreeds { get; set; }
    public List<AdoptedDTO>? Adoptions { get; set; }
}
