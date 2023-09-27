<<<<<<< HEAD
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
=======
using Microsoft.EntityFrameworkCore;

using WebAPI.Models;

namespace WebAPI
{
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            builder.Services.AddControllers();

            // Adding the database context with connection string.
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
>>>>>>> main

var app = builder.Build();

<<<<<<< HEAD
// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();
=======
            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
>>>>>>> main

app.UseHttpsRedirection();

app.UseAuthorization();

<<<<<<< HEAD
app.MapControllers();

app.Run();
=======
            app.Run();
        }
    }
}
>>>>>>> main
