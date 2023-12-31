using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using WebAPI.Services.MovieService;
using AutoMapper;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;

using WebAPI.Data;
using WebAPI.Services;
using WebAPI.Services.CharacterService;
using WebAPI.MappingProfiles;
using WebAPI.Services.FranchiseService;


namespace WebAPI
{
    class Program
    {
        public static void Main(string[] args)
        
        {
            var builder = WebApplication.CreateBuilder(args);

            // AddJsonOptions: Ignore self-referential cycles
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "They shoot pictures don't they?",
                    Description = "The web api that might change your life (if you just let it).",
                    TermsOfService = new Uri("https://google.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "Frederik Strøm Friborg",
                        Url = new Uri("https://github.com/Freddo2300")
                    }
                });

                var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
            
            // Add the database context to the controllers
            builder.Services.AddScoped<ICharacterService, CharacterService>();
            builder.Services.AddScoped<IFranchiseService, FranchiseService>();
            builder.Services.AddScoped<IMovieService, MovieService>(); 

            builder.Services.AddDbContext<WebApiDbContext>();

            builder.Services.AddAutoMapper(typeof(CharacterProfile), typeof(FranchiseProfile), typeof(MovieProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            //dotnet-aspnet-codegenerator -p "/Users/marcpedersem/Documents/experis/assignments/06_assignment/06_assignment.csproj" controller -name testModelController -api -m WebAPI.Controllers -dc DbContext -outDir Controllers -namespace My.Namespace.Controllers

            app.Run();
        }
    }
}

