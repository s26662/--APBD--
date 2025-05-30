
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplication1.Model;
using WebApplication1.Model.DTO;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripController : ControllerBase
{
    
    private readonly IConfiguration _configuration;

    public TripController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetTripAsync(CancellationToken cancellationToken)
    {
        string connectionString = _configuration.GetConnectionString("ConnectionDB");
        
        await using var connection = new SqlConnection(connectionString);
        await using var command = new SqlCommand();
        
        command.Connection = connection;
        command.CommandText = @"Select * from Trip";
        
        await connection.OpenAsync(cancellationToken);
        
        SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);

        var trips = new List<TripDetalisDTO>();
        
        while (await reader.ReadAsync(cancellationToken))
        {
            int idTrip = (int)reader["IdTrip"];
            string name = (string)reader["Name"];
            string description = (string)reader["Description"];
            DateTime dateFrom = (DateTime)reader["DateFrom"];
            DateTime dateTo = (DateTime)reader["DateTo"];
            int maxPeople = (int)reader["MaxPeople"];

            var trip = new TripDetalisDTO
            { 
                IdTrip = idTrip,
                Name = name,
                Description = description,
                DateFrom = dateFrom,
                DateTo = dateTo,
                MaxPeople = maxPeople,
                Countries = new List<CountryInfoDTO>()
            };
            trips.Add(trip);
        }

        await reader.CloseAsync();

        await using var command2 = new SqlCommand();
        command2.Connection = connection;
        
        foreach (var trip in trips )
        {
            command2.CommandText = @"
                           Select c.IdCountry, c.Name 
                           From Country c 
                                join Country_Trip t on c.IdCountry = t.IdCountry 
                            where t.IdTrip = @IdTrip";
            command2.Parameters.Clear();
            command2.Parameters.AddWithValue("@IdTrip", trip.IdTrip);
                
            SqlDataReader readerCountries  = await command2.ExecuteReaderAsync(cancellationToken);
                
            while (await readerCountries.ReadAsync(cancellationToken)) 
            { 
                trip.Countries.Add(new CountryInfoDTO 
                {
                    IdCountry = readerCountries.GetInt32(0), 
                    Name = readerCountries.GetString(1) 
                });
            }
            
            await readerCountries.CloseAsync();

        }
        
        return Ok(trips);
    }
    
}
