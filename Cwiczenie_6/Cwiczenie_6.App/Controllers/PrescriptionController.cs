using Cwiczenie_6.App.DAL;
using Cwiczenie_6.App.Model;
using Cwiczenie_6.App.Model.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenie_6.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
    
    private readonly PharmaDbContex _dbContext;

    public PrescriptionController(PharmaDbContex dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePrescriptionAsync(CreatePrescriptionDto createPrescriptionDto, CancellationToken cancellationToken)
    {
        if (createPrescriptionDto.DueDate < createPrescriptionDto.Date)
        {
            return BadRequest("DueDate must be greater than or equal to Date.");
        }

        if (createPrescriptionDto.Medicaments.Count > 10)
        {
            return BadRequest("A prescription can contain a maximum of 10 medicaments.");
        }

        var doctor = await _dbContext.Doctors.FindAsync(createPrescriptionDto.IdDoctor, cancellationToken);
        if (doctor == null)
        {
            return BadRequest("Doctor not found.");
        }
        
        var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.FirstName == createPrescriptionDto.Patient.FirstName &&
                                                                         p.LastName == createPrescriptionDto.Patient.LastName && 
                                                                         p.Birthdate == createPrescriptionDto.Patient.Birthdate, cancellationToken);

        if (patient == null)
        {
            patient = new Patient
            {
                FirstName = createPrescriptionDto.Patient.FirstName,
                LastName = createPrescriptionDto.Patient.LastName,
                Birthdate = createPrescriptionDto.Patient.Birthdate,
            };
            await _dbContext.Patients.AddAsync(patient);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }


        var prescription = new Prescription
        {
            Date = createPrescriptionDto.Date,
            DueDate = createPrescriptionDto.DueDate,
            IdDoctor = doctor.IdDoctor,
            IdPatient = patient.IdPatient,
        };
        
        await _dbContext.Prescriptions.AddAsync(prescription, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        foreach (var medicamet in createPrescriptionDto.Medicaments)
        {
            var med = await _dbContext.Medicaments.FindAsync(medicamet.IdMedicament, cancellationToken);
            if (med == null)
            {
                BadRequest("Medicament not found.");
            }
            
            await _dbContext.PrescriptionMedicaments.AddAsync(new PrescriptionMedicament
            {
                IdPrescription = prescription.IdPrescription,
                IdMedicament = medicamet.IdMedicament,
                Dose = medicamet.Dose,
                Details = medicamet.Details,
            }, cancellationToken);

        }
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Ok();
    }
}