using Rest_API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//List of Animals
List<Animal> animals =
[
    new Animal()
    {
        Id = 1,
        Name = "Mike",
        Mass = 15.0,
        Color = "Black",
        Category = "Dog",
    },
    new Animal()
    {
        Id = 2,
        Name = "Milk",
        Mass = 8.0,
        Color = "Brown",
        Category = "Cat",
    }

];

//Get => Show list Animal
app.MapGet("/animals/GetListOfAllAnimals", () => animals);

//Get => Find Animal by id
app.MapGet("/animals/GetAnimalById{Id}", (int id) =>
{
    var foundAnimal = animals.Find(a => a.Id == id);
    if (foundAnimal == null)
    {
        return Results.NotFound("Animal not found");
    }
    return Results.Ok(foundAnimal);
});

//Post => Add animal to list
app.MapPost("/animals/AddAnimal", (Animal animal) =>
{
    var foundAnimal = animals.Find(a => a.Id == animal.Id);
    if (foundAnimal == null)
    {
        animals.Add(animal);
        return Results.Created($"/animals/{animal.Id}", animal);
    }
    
    return Results.BadRequest("Animal already exists");
});


app.Run();
