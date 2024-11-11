using System.ComponentModel.DataAnnotations;

namespace api.Dto;

public record RegisterDto() 
{
    [Required]
    public required  string Username { get; init; }
    
    [Required]
    public required string Password { get; init; }
}