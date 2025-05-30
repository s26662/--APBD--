using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model.DTO;

public class CreateClientDTO
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Telephone { get; set; }
    [Required]
    public string Pesel { get; set; }
}