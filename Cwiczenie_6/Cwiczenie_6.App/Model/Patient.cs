using System.ComponentModel.DataAnnotations;

namespace Cwiczenie_6.App.Model;

public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    public DateTime Birthdate { get; set; }
}