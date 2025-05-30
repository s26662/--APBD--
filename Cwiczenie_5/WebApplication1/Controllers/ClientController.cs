using Microsoft.AspNetCore.Http.HttpResults;
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


    [HttpPost]
    public async Task<IActionResult> CreateClientAsync(CreateClientDTO newClient, CancellationToken cancellationToken)
    {
        string connectionString = _configuration.GetConnectionString("ConnectionDB");
        
        await using var connection = new SqlConnection(connectionString);
        await using var command = new SqlCommand();
        
        command.Connection = connection;
        
        command.CommandText = @" Insert into Client (FirstName, LastName, Email, Telephone, Pesel)
                    Values (@FirstName, @LastName, @Email, @Telephone, @Pesel);
                    Select SCOPE_IDENTITY();";
        
        command.Parameters.AddWithValue("@FirstName", newClient.FirstName);
        command.Parameters.AddWithValue("@LastName", newClient.LastName);
        command.Parameters.AddWithValue("@Email", newClient.Email);
        command.Parameters.AddWithValue("@Telephone", newClient.Telephone);
        command.Parameters.AddWithValue("@Pesel", newClient.Pesel);
        

        await connection.OpenAsync(cancellationToken);
        
        var clientid = await command.ExecuteScalarAsync(cancellationToken);
        var newClientId = Convert.ToInt32(clientid);
        
        
        return Created($"/Client/{clientid}", new {message = "Client was created",IdClient = newClientId});
    }

    [HttpPut("{id}/trips/{tripId}")]
    public async Task<IActionResult> UpdateClientTripAsync(int clientId, int tripId, CancellationToken cancellationToken)
    {
        string connectionString = _configuration.GetConnectionString("ConnectionDB");
        
        await using var connection = new SqlConnection(connectionString);
        await using var command = new SqlCommand();
        
        command.Connection = connection;
        await connection.OpenAsync(cancellationToken);
        
        
        command.CommandText = "Select 1 from Client where IdClient = @ClientId";
        command.Parameters.AddWithValue("@ClientId", clientId);
        var clientExists = await command.ExecuteScalarAsync(cancellationToken) != null;

        if (!clientExists)
            return NotFound($"Client with ID {clientId} does not exist.");
        
        
        command.CommandText = "Select MaxPeople from Trip where IdTrip = @TripId";
        command.Parameters.Clear();
        command.Parameters.AddWithValue("@TripId", tripId);
        var maxPeopleObj = await command.ExecuteScalarAsync(cancellationToken);

        if (maxPeopleObj == null)
            return NotFound($"Trip with ID {tripId} does not exist.");
        
        var maxPeople = Convert.ToInt32(maxPeopleObj);
        
        command.CommandText = "Select COUNT(*) from Client_Trip where IdTrip = @TripId";
        command.Parameters.Clear();
        command.Parameters.AddWithValue("@TripId", tripId);
        var currentPeople = (int)await command.ExecuteScalarAsync(cancellationToken);

        if (currentPeople >= maxPeople)
            return BadRequest("Trip is already full.");
        
        command.CommandText = "Select 1 from Client_Trip where IdClient = @ClientId and IdTrip = @TripId";
        command.Parameters.Clear();
        command.Parameters.AddWithValue("@ClientId", clientId);
        command.Parameters.AddWithValue("@TripId", tripId);
        
        var alreadyRegistered = await command.ExecuteScalarAsync(cancellationToken) != null;

        if (alreadyRegistered)
            return Conflict("Client is already registered for this trip.");
        
        command.CommandText = @"
        Insert Into Client_Trip (IdClient, IdTrip, RegisteredAt, PaymentDate)
        Values (@ClientId, @TripId, @RegisteredAt, NULL)";
        
        command.Parameters.AddWithValue("@IdClient", clientId);
        command.Parameters.AddWithValue("@IdTrip", tripId);
        
        int day = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
        command.Parameters.AddWithValue("@RegisteredAt", day);

        var result = await command.ExecuteNonQueryAsync(cancellationToken);

        return result > 0
            ? Ok("Client successfully registered for the trip.")
            : StatusCode(500, "Failed to register client.");
    }


    [HttpDelete("{id}/trips/{tripId}")]
    public async Task<IActionResult> DeleteClientAsync(int clientId, int tripId, CancellationToken cancellationToken)
    {
        string connectionString = _configuration.GetConnectionString("ConnectionDB");
        await using var connection = new SqlConnection(connectionString);
        await using var command = new SqlCommand();
        
        command.Connection = connection;
        await connection.OpenAsync(cancellationToken);
        
        var checkCmd = new SqlCommand("Select COUNT(*) From Client_Trip Where IdClient = @IdClient And IdTrip = @IdTrip", connection);
        checkCmd.Parameters.AddWithValue("@IdClient", clientId);
        checkCmd.Parameters.AddWithValue("@IdTrip", tripId);

        var exists = (int)await checkCmd.ExecuteScalarAsync(cancellationToken);
        if (exists == 0)
        {
            return NotFound($"Client with id {clientId} is not registered for trip {tripId}.");
        }
        
        var deleteCmd = new SqlCommand("Delete From Client_Trip Where IdClient = @IdClient And IdTrip = @IdTrip", connection);
        deleteCmd.Parameters.AddWithValue("@IdClient", clientId);
        deleteCmd.Parameters.AddWithValue("@IdTrip", tripId);

        var rowsAffected = await deleteCmd.ExecuteNonQueryAsync(cancellationToken);
        if (rowsAffected == 0)
        {
            return StatusCode(500, "An error occurred while deleting the client from the trip.");
        }
        
        
        return Ok($"Client {clientId} was removed from trip {tripId}.");
    }



}