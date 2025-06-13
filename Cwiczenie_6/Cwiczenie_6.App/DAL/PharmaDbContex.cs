using Cwiczenie_6.App.Model;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenie_6.App.DAL;

public class PharmaDbContex : DbContext
{
    public DbSet<Patient> Patients { get; set; }

    protected PharmaDbContex()
    {
    }

    public PharmaDbContex(DbContextOptions options) : base(options)
    {
    }
}