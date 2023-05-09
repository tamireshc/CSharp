using Newtonsoft.Json;
using System.Text;
using pet_care.Models;

namespace pet_care.Test;

public class PetCareTest : IClassFixture<TestingWebAppFactory<Program>>
{
  private readonly HttpClient _client;

  public PetCareTest(TestingWebAppFactory<Program> factory)
      => _client = factory.CreateClient();

  [Fact]
  public async Task ShouldCreateAnAppointment()
  {
    var jsonToAdd = "{\"vetId\":0,\"vet\":{\"vetId\":0,\"name\":\"string\",\"address\":\"string\",\"phone\":\"string\",\"email\":\"string\",\"specialtyId\":0,\"specialty\":{\"specialtyId\":0,\"name\":\"string\"}},\"petId\":0,\"pet\":{\"petId\":0,\"name\":\"string\",\"description\":\"string\",\"age\":0,\"breedId\":0,\"breed\":{\"breedId\":0,\"name\":\"string\",\"description\":\"string\"}}}";

    var stringContent = new StringContent(jsonToAdd, Encoding.UTF8, "application/json");
    var result = await _client.PostAsync("/api/Appointment", stringContent);
    result.StatusCode.Should().Be((System.Net.HttpStatusCode)200);
  }
}