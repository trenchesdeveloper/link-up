using System.ComponentModel.DataAnnotations;

namespace api.Dto;

public record LoginDto() 
{
    [Required]
    public required string Username { get; init; }
    
    [Required]
    public required string Password { get; init; }
}