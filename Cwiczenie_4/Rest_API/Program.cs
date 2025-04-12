using System.Collections.Immutable;
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

List < Visits > visitsList = [
new Visits()
{
    Date = DateTime.Now,
    Animal = new Animal()
    {
        Id = 1,
        Name = "Mike",
        Mass = 15.0,
        Color = "Black",
        Category = "Dog",
    },
    Description = "Yearly visit",
    Price = 100.0
}

];

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

//Get => Show list Animal
app.MapGet("/animals/GetListOfAllAnimals", () => animals);

//Get => Find Animal by id
app.MapGet("/animals/GetAnimalById/{id}", (int id) =>
{
    var foundAnimal = animals.Find(a => a.Id == id);
    if (foundAnimal == null)
    {
        return Results.NotFound("Animal not found");
    }
    return Results.Ok(foundAnimal);
});

//Get => Find animal by name
app.MapGet("/animals/GetAnimalByName/{name}", (string name) =>
{
    var foundAnimal = animals.Find(a => a.Name == name);
    if (foundAnimal == null)
    {
        return Results.NotFound("Animal by name not found");
    }
    
    return Results.Ok(foundAnimal);
});

//Delete => Delete animal by id
app.MapDelete("/animals/DeleteAnimal/{Id}", (int id) =>
{
    var foundAnimal = animals.Find(a => a.Id == id);
    if (foundAnimal != null)
    {
        animals.Remove(foundAnimal);
        return Results.Ok("Animal deleted");
    }
    
    return Results.NotFound("Animal by id not found");
});

//Put => Editing data for animal
app.MapPut("/animals/EditData", (Animal animal) =>
{
    var foundAnimal = animals.Find(a => a.Id == animal.Id);
    if (foundAnimal == null)
    {
        return Results.NotFound("Animal not found");
    }
    
    foundAnimal.Name = animal.Name;
    foundAnimal.Color = animal.Color;
    foundAnimal.Mass = animal.Mass;
    
    return Results.Ok("Animal updated");
});

//Get => Find visit for animal
app.MapGet("/visits/GetListOfVisits/{Id}", (int id) =>
{
    var foundVisit = visitsList.Where(v => v.Animal.Id == id).ToList();
    if (foundVisit == null)
    {
        return Results.NotFound("Visit not found");
    }
    return Results.Ok(foundVisit);
});

app.Run();
