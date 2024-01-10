using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApiCA2.Repository;

var builder = WebApplication.CreateBuilder(args);

//ADDING SERVICE FOR DATABASE CONNECTION
//CONNECTION STRING IS IN APPSETTINGS.JSON FILE 
//

//registering the connection string od DB context
//this are injected at runtime.
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDbContext") ?? throw new InvalidOperationException("Connection string 'UserDataContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
///registering the mapper for DTOs
//adding service for AUTOMAPPER
builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();



//MAPPING CONTROLLERS TO ENDPOINTS
app.MapControllers();


app.Run();
