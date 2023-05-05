using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using auth_api.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace auth_api.Test;
public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    builder.ConfigureServices(services =>
    {
      var descriptor = services.SingleOrDefault(
              d => d.ServiceType ==
                  typeof(DbContextOptions<AuthContext>));
      if (descriptor != null)
        services.Remove(descriptor);
      services.AddDbContext<AuthContext>(options =>
          {
            options.UseInMemoryDatabase("InMemoryQuizTest");
          });
      var sp = services.BuildServiceProvider();
      using (var scope = sp.CreateScope())
      using (var appContext = scope.ServiceProvider.GetRequiredService<AuthContext>())
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