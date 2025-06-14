﻿using System.Text.Json.Serialization;

namespace Cwiczenie_6.App.Model.DTOs;

public class PatientDetailsDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime Birthdate { get; set; }
    
    public List<PrescriptionDto> Prescriptions { get; set; }
}

public class PrescriptionDto
{
    public int IdPrescription { get; set; }
    
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime Date { get; set; }
    
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime DueDate { get; set; }
    public DoctorDto Doctor { get; set; }
    
    public List<MedicamentDto> Medicaments { get; set; }
}

public class DoctorDto
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}

public class MedicamentDto
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public int? Dose { get; set; }
    public string Details { get; set; }
}