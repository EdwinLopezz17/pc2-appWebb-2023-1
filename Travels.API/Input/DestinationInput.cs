using System.ComponentModel.DataAnnotations;

namespace Travels.API.Input;

public class DestinationInput
{
    [Required]
    public string name { get; set; }
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "maxUsers must be greater than zero.")]
    public int maxUsers { get; set; }
    
    [Required]
    [Range(0, 1, ErrorMessage = "Only values between 0 and 1 are accepted.")]
    public int isRisky { get; set; }
}