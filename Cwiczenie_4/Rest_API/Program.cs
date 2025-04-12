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

List<Animal> animals =
[
    new Animal()
    {
        Id = 1,
        Name = "Mike",
        Mass = 15.0,
        Color = "Black",
        Category = Category.Dog,
    },
    new Animal()
    {
        Id = 2,
        Name = "Milk",
        Mass = 8.0,
        Color = "Brown",
        Category = Category.Cat,
    }

];

app.MapGet("/animals/GetListOfAllAnimals", () => animals);

app.Run();
