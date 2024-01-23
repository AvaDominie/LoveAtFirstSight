using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LoveAtFirstSight.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    public string FullName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public bool Employee { get; set; }
    public IdentityUser IdentityUser { get; set; }
    public List<Adopted> Adoptions { get; set; }
}