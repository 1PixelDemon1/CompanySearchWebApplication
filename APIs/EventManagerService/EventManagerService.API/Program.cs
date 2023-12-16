
using EventManagerService.API.Config;
using EventManagerService.Application;
using EventManagerService.Infrastructure;
using EventManagerService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EventManagerService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


            var app = builder.Build();
            
            app.UseSwagger();
            app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            ApplyMigration(app);

            app.Run();
        }

        public static void ApplyMigration(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<EventManagerDbContext>();

                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
        }
    }
}