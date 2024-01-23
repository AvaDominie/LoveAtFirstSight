
using System.ComponentModel.DataAnnotations;

namespace LoveAtFirstSight.Models;

public class Animal
{
    public int Id { get; set; }
    [Required]
    public bool IsDog { get; set; }
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
    public List<AnimalBreed> AnimalBreeds { get; set; }
}