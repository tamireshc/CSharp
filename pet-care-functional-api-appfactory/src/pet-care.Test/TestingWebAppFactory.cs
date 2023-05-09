using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using pet_care.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace pet_care.Test;
public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    builder.ConfigureServices(services =>
    {
      var descriptor = services.SingleOrDefault(
              d => d.ServiceType ==
                  typeof(DbContextOptions<PetCareContext>));
      if (descriptor != null)
        services.Remove(descriptor);
      services.AddDbContext<PetCareContext>(options =>
          {
            options.UseInMemoryDatabase("InMemoryPetTest");
          });
      var sp = services.BuildServiceProvider();
      using (var scope = sp.CreateScope())
      using (var appContext = scope.ServiceProvider.GetRequiredService<PetCareContext>())
      {
        try
        {
          appContext.Database.EnsureCreated();

        }
        catch (Exception e)
        {
          throw e;
        }
      }
    });
  }
}