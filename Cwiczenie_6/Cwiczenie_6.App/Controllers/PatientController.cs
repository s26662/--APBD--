using Cwiczenie_6.App.DAL;
using Cwiczenie_6.App.Model;
using Cwiczenie_6.App.Model.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Cwiczenie_6.App.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly PharmaDbContex _dbContext;

    public PatientController(PharmaDbContex dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{id}")]
    public async Task<PatientDetails> GetPatient(CancellationToken cancellationToken, int id)
    {
        var data = await _dbContext.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.Doctor)
            .FirstOrDefaultAsync(p => p.IdPatient == id, cancellationToken);

        if (data == null)
        {
            throw new KeyNotFoundException("No Patient found");
        }

        return new PatientDetails
        {
            IdPatient = data.IdPatient,
            FirstName = data.FirstName,
            LastName = data.LastName,
            Birthdate = data.Birthdate,
            Prescriptions = data.Prescriptions
                .OrderBy(p => p.DueDate)
                .Select(p => new PrescriptionDto
                {
                    IdPrescription = p.IdPrescription,
                    Date = p.Date,
                    DueDate = p.DueDate,
                    Medicaments = p.PrescriptionMedicaments.Select(m => new MedicamentDto
                    {
                        IdMedicament = m.Medicament.IdMedicament,
                        Name = m.Medicament.Name,
                        Description = m.Medicament.Description,
                        Type = m.Medicament.Type,
                        Dose = m.Dose,
                        Details = m.Details
                    }).ToList(),
                    Doctor = new DoctorDto
                    {
                        IdDoctor = p.Doctor.IdDoctor,
                        FirstName = p.Doctor.FirstName,
                        LastName = p.Doctor.LastName,
                        Email = p.Doctor.Email,
                    }
                }).ToList()
        };
    }
}