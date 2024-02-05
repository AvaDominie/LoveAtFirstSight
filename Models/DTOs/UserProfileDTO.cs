using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LoveAtFirstSight.Models.DTOs;

public class UserProfileDTO
{
    public int Id { get; set; }
    [Required]
    public string? FullName { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Address { get; set; }
    public string? UserName { get; set; }
    public List<string>? Roles { get; set; }
    public bool? Employee { get; set; }
    [Required]
    public string? IdentityUserId { get; set; }
    public IdentityUser? IdentityUser { get; set; }
    public List<AdoptedDTO>? Adoptions { get; set; }
}