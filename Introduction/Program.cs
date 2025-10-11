using Introduction.Data;
using Introduction.Repositories;
using Introduction.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();







builder.Services.AddDbContext<TestDataDBContext>(
    option => option.UseSqlServer(
        builder.Configuration.GetConnectionString("TestConnection"))
    );


//DI
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
//DI
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddCors((cors) =>
{
    cors.AddPolicy("AllowLocalhost4200", policy =>
    {
        policy.
        WithOrigins("http://localhost:4200").
        AllowAnyHeader().
        AllowAnyMethod();
    });
});

//http://localhost:4200

//https://localhost:7115/api/Employees/GetEmpName

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseCors("AllowLocalhost4200");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
