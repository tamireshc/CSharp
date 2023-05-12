using System.Net.Http.Headers;
using MyWine.Models;
using MyWine.Services;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MyWine.Test;

public class TestAuthorizeMessageController : IClassFixture<WebApplicationFactory<Program>>
{

  private readonly WebApplicationFactory<Program> _factory;

  public TestAuthorizeMessageController(WebApplicationFactory<Program> factory)
  {
    _factory = factory;
  }

  [Theory(DisplayName = "Teste para MessageForCustomOffer com Status OK")]
  [InlineData("Bahia", "Lover")]
  [InlineData("Bahia", "Specialist")]
  [InlineData("Ceará", "Lover")]
  [InlineData("Ceará", "Specialist")]
  [InlineData("Minas Gerais", "Lover")]
  [InlineData("Minas Gerais", "Specialist")]
  [InlineData("Roraima", "Lover")]
  [InlineData("Roraima", "Specialist")]
  public async Task TestMessageForCustomOfferSuccess(string state, string type)
  {
    var user = new User { State = state, Lover = type };

    var client = _factory.CreateClient();
    var token = new TokenGenerator().Generate(user);
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    var result = await client.GetAsync("Notification/NotifyCustomCustomers");
    result.StatusCode.Should().Be((System.Net.HttpStatusCode)200);
  }

  [Theory(DisplayName = "Teste para MessageForCustomOffer com Status Forbidden")]
  [InlineData("São Paulo", "Lover")]
  [InlineData("Rio de Janeiro", "Specialist")]
  [InlineData("Acre", "Specialist")]
  [InlineData("Ceará", "Basic")]
  [InlineData("Minas Gerais", "Basic")]
  [InlineData("Roraima", "Basic")]
  public async Task TestMessageForCustomOfferFail(string state, string type)
  {
    var user = new User { State = state, Lover = type };
    var client = _factory.CreateClient();
    var token = new TokenGenerator().Generate(user);
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    var result = await client.GetAsync("Notification/NotifyCustomCustomers");
    result.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
  }

  [Theory(DisplayName = "Teste para MessageForCustomers com Status OK")]
  [InlineData("Bahia", "Lover")]
  [InlineData("Bahia", "Specialist")]
  [InlineData("Ceará", "Lover")]
  [InlineData("Ceará", "Specialist")]
  [InlineData("Minas Gerais", "Lover")]
  [InlineData("Minas Gerais", "Specialist")]
  [InlineData("Roraima", "Lover")]
  [InlineData("Roraima", "Specialist")]
  [InlineData("São Paulo", "Lover")]
  [InlineData("Rio de Janeiro", "Specialist")]
  [InlineData("Acre", "Specialist")]
  [InlineData("Ceará", "Basic")]
  [InlineData("Minas Gerais", "Basic")]
  [InlineData("Roraima", "Basic")]
  public async Task TestMessageForCustomersSuccess(string state, string type)
  {
    var user = new User { State = state, Lover = type };

    var client = _factory.CreateClient();
    var token = new TokenGenerator().Generate(user);
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    var result = await client.GetAsync("Notification/NotifyCustomers");
    result.StatusCode.Should().Be((System.Net.HttpStatusCode)200);

  }

  [Theory(DisplayName = "Teste para MessageForCustomers com Status Unauthorized")]
  [InlineData("TOKENINVALIDO")]
  [InlineData("TRYBE")]
  [InlineData("123456789")]
  public async Task TestMessageForCustomersFail(string token)
  {

    var client = _factory.CreateClient();
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    var result = await client.GetAsync("Notification/NotifyCustomers");
    result.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
  }

  [Fact(DisplayName = "Teste para MessageForEveryone com Status Ok")]
  public async Task TestMessageForEveryoneSuccess()
  {
    var _client = _factory.CreateClient();
    var result = await _client.GetAsync("Notification/NotifyEveryone");
    result.StatusCode.Should().Be((System.Net.HttpStatusCode)200);
  }

}
