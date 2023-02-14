using Microsoft.EntityFrameworkCore;
using BugsTrackingSystem.Models;
using BugsTrackingSystem.DAL;
using BugsTrackingSystem.Services;

namespace BugsTrackingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BugsResolvingContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Development"));
            });

            builder.Services.AddControllers();
            builder.Services.AddScoped<IBugsService, BugsService>();
            builder.Services.AddScoped<IMessagesService, MessagesService>();
            builder.Services.AddScoped<IProjectsService, ProjectsService>();
            var app = builder.Build();

            app.MapControllers();

            app.Run();


        }
    }
}