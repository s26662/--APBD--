using Cwiczenie_6.App.DAL;
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

    [HttpGet]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        
        return Ok();
    }
}