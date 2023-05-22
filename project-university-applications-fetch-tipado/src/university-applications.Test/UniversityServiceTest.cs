using System.Text.Json;
using Moq;
using university_applications.Services;

namespace university_applications.Test;

public class UniversityServiceTest
{

  [Fact]
  public async Task ShouldReturnUniversityByCountryAndName()
  {
    var mockClient = new Mock<HttpClient>();
    var universityService = new UniversityService(mockClient.Object);
    var response = await universityService.FindUniversity("middle", "turkey");
    response.Should().BeOfType<JsonElement>();
    response.ToString().ToLower().Should().Contain("turkey");
    response.ToString().ToLower().Should().Contain("middle");

  }
  // ValueKind = Array : "[{"country": "Turkey", "alpha_two_code": "TR", "web_pages": ["http://www.metu.edu.tr/"], "state-province": null, "domains": ["metu.edu.tr"], "name": "Middle East Technical University"}]"

  [Fact]

  public async Task ShouldReturnAUniversityByCountry()
  {
    var mockClient = new Mock<HttpClient>();
    var universityService = new UniversityService(mockClient.Object);
    var response = await universityService.FindUniversity("turkey");
    response.Should().BeOfType<JsonElement>();
    response.ToString().ToLower().Should().Contain("turkey");

  }
}

