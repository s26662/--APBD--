namespace Cwiczenie_6.App.Model.DTOs;

public class CreatePrescriptionDto
{
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public int IdDoctor { get; set; }
    public PatientDto Patient { get; set; }
    
    public List<PrescriptionMedicamentDto> Medicaments { get; set; }
}


public class PatientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
}

public class PrescriptionMedicamentDto
{
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    public string Details { get; set; }
}