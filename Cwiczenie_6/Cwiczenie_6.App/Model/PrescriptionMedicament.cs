using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenie_6.App.Model;

[PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))]
public class PrescriptionMedicament
{
    
    public int? Dose { get; set; }
    [Required]
    [MaxLength(100)]
    public string Details { get; set; }
    
    public Prescription Prescription { get; set; }
    
    [ForeignKey(nameof(Prescription))]
    public int IdPrescription { get; set; }
    
    public Medicament Medicament { get; set; }
    [ForeignKey(nameof(Medicament))]
    public int IdMedicament { get; set; }
    
    
}