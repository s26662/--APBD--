using System.ComponentModel.DataAnnotations;

namespace Cwiczenie_6.App.Model;

public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
  
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public ICollection<Prescription> Prescriptions { get; set; }
}