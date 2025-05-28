using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace WebApplication1.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{

    [HttpGet]
    public IActionResult Get()
    {

        var connectionString = new SqlConnection();
        
        var command = new SqlCommand();
        
        return Ok();
    }

}