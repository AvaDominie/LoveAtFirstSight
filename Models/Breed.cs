
using System.ComponentModel.DataAnnotations;

namespace LoveAtFirstSight.Models;

public class Breed
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}