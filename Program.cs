using AutoMapper;

namespace WebAPI.Data.DTO


{
    class Program
    {

        public void ConfigureServices(IServiceCollection services)
        {
    

        services.AddAutoMapper(typeof(MappingProfile));
        }

        public static void Main(string[] args)
        
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

        

            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

