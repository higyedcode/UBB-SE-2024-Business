using NamespaceGPT_ASP.NET_Repository.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace NamespaceGPT_ASP.NET_Repository
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Configuration.GetConnectionString("defaultConnection");
            // Add database context to the container.
            // This will suffice for our team, maybe we'll use something like sqlite later on, and who knows what insanity will arise @ the MAREA UNIRE.
            builder.Services.AddDbContext<ProjectDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

            var app = builder.Build();

            var options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            options.DefaultFileNames.Add("help.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();
            app.UseRouting();

            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
