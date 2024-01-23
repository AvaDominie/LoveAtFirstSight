using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LoveAtFirstSight.Models.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    [Required]
    public string FullName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Address { get; set; }
    public bool Employee { get; set; }
    public IdentityUser IdentityUser { get; set; }
}