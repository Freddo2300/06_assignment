namespace WebAPI
{
    class Program
    {
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
            //dotnet-aspnet-codegenerator -p "/Users/marcpedersem/Documents/experis/assignments/06_assignment/06_assignment.csproj" controller -name testModelController -api -m  -dc MyDemoDbContext -outDir Controllers -namespace My.Namespace.Controllers

            app.Run();
        }
    }
}
