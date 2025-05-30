using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplication1.Model;
using WebApplication1.Model.DTO;

namespace WebApplication1.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    
    private readonly IConfiguration _configuration;

    public ClientController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("{id}/trips")]
    public async Task<IActionResult> GetTripByIdAsync(int id, CancellationToken cancellationToken)
    {
        string connectionString = _configuration.GetConnectionString("ConnectionDB");

        
        var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);
        
        
        await using var checkClient = new SqlCommand();
        checkClient.Connection = connection;
        checkClient.CommandText = "SELECT COUNT(*) FROM Client WHERE IdClient = @IdClient";
        checkClient.Parameters.AddWithValue("@IdClient", id);

        int count = (int)await checkClient.ExecuteScalarAsync();

        if (count == 0)
        {
            return NotFound($"Client with ID {id} not found");
        }
        
        var command = new SqlCommand();
        
        command.Connection = connection;
        command.CommandText = @"
                  Select t1.IdTrip, t1.Name, t1.Description, t1.DateFrom, t1.DateTo, t1.MaxPeople,
                         t2.RegisteredAt, t2.PaymentDate, t2.IdClient
                  From Trip t1
                      join Client_Trip t2 on t1.IdTrip = t2.IdTrip 
                  where t2.IdClient = @IdClient";
        command.Parameters.AddWithValue("@IdClient", id);
        
        SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
        
        var tripsClients = new List<CheckClientTripDTO>();

        while (await reader.ReadAsync(cancellationToken))
        {
            int idClient = (int)reader["IdClient"];
            int idTrip = (int)reader["IdTrip"];
            string name = (string)reader["Name"];
            string description = (string)reader["Description"];
            DateTime dateFrom = (DateTime)reader["DateFrom"];
            DateTime dateTo = (DateTime)reader["DateTo"];
            int maxPeople = (int)reader["MaxPeople"];
            int registeredAt = (int)reader["RegisteredAt"];
            int? paymentDate = reader["PaymentDate"] == DBNull.Value ? (int?)null : (int)reader["PaymentDate"];

            var tripClient = new CheckClientTripDTO
            {
                IdClient = idClient,
                IdTrip = idTrip,
                Name = name,
                Description = description,
                DateFrom = dateFrom,
                DateTo = dateTo,
                MaxPeople = maxPeople,
                RegisteredAt = registeredAt,
                PaymentDate = paymentDate,
                Countries = new List<CountryInfoDTO>()
            };
            tripsClients.Add(tripClient);
        }
        
        await reader.CloseAsync();
        
        await using var command2 = new SqlCommand();
        command2.Connection = connection;
        
        foreach (var trip in tripsClients)
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
        


        return Ok(tripsClients);
    }
    
}