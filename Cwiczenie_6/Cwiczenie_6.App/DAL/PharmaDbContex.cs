using Cwiczenie_6.App.Model;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenie_6.App.DAL;

public class PharmaDbContex : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected PharmaDbContex()
    {
    }

    public PharmaDbContex(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        //Seed Doctor
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { IdDoctor = 1, FirstName = "Elżbieta", LastName = "Nowak", Email = "elzbieta.nowak@clinic.pl" },
            new Doctor { IdDoctor = 2, FirstName = "Tomasz", LastName = "Kowalski", Email = "tomasz.kowalski@clinic.pl" },
            new Doctor { IdDoctor = 3, FirstName = "Michał", LastName = "Wiśniewski", Email = "michal.wisniewski@clinic.pl" }
        );
        
        //Seed Patient
        modelBuilder.Entity<Patient>().HasData(
            new Patient { IdPatient = 1, FirstName = "Katarzyna", LastName = "Zielińska", Birthdate = new DateTime(1989, 3, 22) },
            new Patient { IdPatient = 2, FirstName = "Paweł", LastName = "Adamski", Birthdate = new DateTime(1992, 7, 9) },
            new Patient { IdPatient = 3, FirstName = "Marcin", LastName = "Szymański", Birthdate = new DateTime(1975, 12, 1) }
        );

        
        //Seed Medicament
        modelBuilder.Entity<Medicament>().HasData(
            new Medicament { IdMedicament = 1, Name = "Ketonal", Description = "Silny lek przeciwbólowy", Type = "NLPZ" },
            new Medicament { IdMedicament = 2, Name = "Fervex", Description = "Na przeziębienie", Type = "Leki OTC" },
            new Medicament { IdMedicament = 3, Name = "Propranolol", Description = "Na nadciśnienie", Type = "Beta-bloker" }
        );

        //Seed Prescription
        modelBuilder.Entity<Prescription>().HasData(
            new Prescription { IdPrescription = 1, Date = new DateTime(2025, 6, 10), DueDate = new DateTime(2025, 6, 20), IdPatient = 1, IdDoctor = 1 },
            new Prescription { IdPrescription = 2, Date = new DateTime(2025, 6, 11), DueDate = new DateTime(2025, 6, 21), IdPatient = 2, IdDoctor = 2 },
            new Prescription { IdPrescription = 3, Date = new DateTime(2025, 6, 12), DueDate = new DateTime(2025, 6, 22), IdPatient = 3, IdDoctor = 3 }
        );

        //Seed PrescriptionMedicament
        modelBuilder.Entity<PrescriptionMedicament>().HasData(
            new PrescriptionMedicament { IdPrescription = 1, IdMedicament = 1, Dose = 50, Details = "2x dziennie po posiłku" },
            new PrescriptionMedicament { IdPrescription = 1, IdMedicament = 2, Dose = 1, Details = "1 saszetka wieczorem" },
            new PrescriptionMedicament { IdPrescription = 2, IdMedicament = 3, Dose = 10, Details = "1 rano na czczo" },
            new PrescriptionMedicament { IdPrescription = 3, IdMedicament = 1, Dose = 25, Details = "Tylko w razie bólu" }
        );

    }
}