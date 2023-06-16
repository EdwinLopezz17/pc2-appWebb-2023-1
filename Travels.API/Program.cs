using Microsoft.EntityFrameworkCore;
using Travels.API.Mapper;
using Travels.Domain;
using Travels.Infraestructure;
using TravelsInfraestructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//dependecy inyection
builder.Services.AddScoped<IDestinationInfraestructure, DestinationMySQLInfraestructure>();
builder.Services.AddScoped<IDestinationDomain, DestinationDomain>();

//conection to MySQL
var connectionString = builder.Configuration.GetConnectionString("travelConnection");

builder.Services.AddDbContext<TravelsInfraestructureDBContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });

builder.Services.AddAutoMapper(
    typeof(ModelToResponse),
    typeof(RequestToModel)
);


var app = builder.Build();
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<TravelsInfraestructureDBContext>())
{
    context.Database.EnsureCreated();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();