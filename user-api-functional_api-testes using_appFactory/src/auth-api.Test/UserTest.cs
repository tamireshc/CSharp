using auth_api.Repository;
using auth_api.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace auth_api.Test;

public class UserTest : IClassFixture<TestingWebAppFactory<Program>>
{
    public UserTest(TestingWebAppFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }
    private readonly HttpClient _client;

    [Fact]
    public async Task ShouldReturnUserData()
    {
        var jsonToAdd = "{\"fullName\": \"Joe Doe\",\"password\": \"123\",\"email\": \"email@email.com\" }";

        var stringContent = new StringContent(jsonToAdd, Encoding.UTF8, "application/json");
        var result = await _client.PostAsync("/user", stringContent);
        result.StatusCode.Should().Be((System.Net.HttpStatusCode)200);
    }

    [Fact]
    public async Task ShouldReturnAllUsers()
    {
        await _client.DeleteAsync("/user");
        var result = await _client.GetAsync("/user");
        result.Should().BeSuccessful();
        // var allUsers = await result.Content.ReadAsStringAsync();
        // allUsers.Should().BeEquivalentTo("[{\"userId\":1,\"fullName\":\"Joe Doe\",\"password\":\"123\",\"email\":\"email@email.com\"},{\"userId\":2,\"fullName\":\"Joe Doe\",\"password\":\"123\",\"email\":\"email@email.com\"}]");
    }
}

