
using CustomerManagementService.Data;
using CustomerManagementService.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementService;
/// <summary>
/// The main entry point of the Customer Management Service application.
/// Configures and runs the web api.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Get the connection string from app-settings.
        builder.Services.AddDbContext<CustomerContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<CustomerViewModel>();
        builder.Services.AddScoped<ProductViewModel>();
        builder.Services.AddScoped<OrderViewModel>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            // Seed the database
            using IServiceScope scope = app.Services.CreateScope();
            IServiceProvider services = scope.ServiceProvider;
            CustomerContext context = services.GetRequiredService<CustomerContext>();
            DbInitializer.Initialize(context);
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
