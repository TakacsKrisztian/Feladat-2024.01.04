
using MySqlConnector;

namespace Feladat_2023._01._04
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<PoliticalDbContext>();     
            builder.Services.AddScoped<IPoliticalPartyInterface, politicalpartyService>();
            builder.Services.AddScoped<IPoliticianInterface, politicianService>();
            
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}