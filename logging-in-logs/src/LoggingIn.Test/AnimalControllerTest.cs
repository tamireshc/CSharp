using LoggingIn.Test.Extensions;

namespace LoggingIn.Test;

public class AnimalControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly Mock<IAnimalRepository> _repositoryMock;
    public readonly Mock<ILogger<AnimalController>> _loggerMock;

    public AnimalControllerTest(WebApplicationFactory<Program> factory)
    {
        _repositoryMock = new Mock<IAnimalRepository>(MockBehavior.Strict);
        _loggerMock = new Mock<ILogger<AnimalController>>();

        _client = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IAnimalRepository>(st => _repositoryMock.Object);
                services.AddScoped<ILogger<AnimalController>>(st => _loggerMock.Object);
            });
        }).CreateClient();
    }

    [Fact]
    public async Task GetAllSuccessTest()
    {
        var animals = AutoFaker.Generate<Animal>(3);
        _repositoryMock.Setup(r => r.GetAll()).Returns(animals);

        var response = await _client.GetAsync("/animals");
        var content = await response.Content.ReadFromJsonWithEnumAsync<IEnumerable<Animal>>();

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().BeEquivalentTo(animals);

        _repositoryMock.Verify(r => r.GetAll(), Times.Once);

        _loggerMock.Verify(x => x.Log(
            It.Is<LogLevel>(ll => ll == LogLevel.Information),
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "GetAll executed with 3 animals"
               && @type.Name == "FormattedLogValues"),
            It.IsAny<Exception>(),
            (Func<It.IsAnyType, Exception?, string>)It.IsAny<object>()),
        Times.Once);
    }

    [Fact]
    public async Task GetByIdSuccessTest()
    {
        var animal = AutoFaker.Generate<Animal>();
        animal.Id = 1;

        _repositoryMock.Setup(r => r.GetById(animal.Id)).Returns(animal);

        var response = await _client.GetAsync("/animals/1");
        var content = await response.Content.ReadFromJsonWithEnumAsync<Animal>();

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().BeEquivalentTo(animal);

        _repositoryMock.Verify(r => r.GetById(1), Times.Once);

        _loggerMock.Verify(x => x.Log(
            It.Is<LogLevel>(ll => ll == LogLevel.Information),
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "GetById executed with id 1"
               && @type.Name == "FormattedLogValues"),
            It.IsAny<Exception>(),
            (Func<It.IsAnyType, Exception?, string>)It.IsAny<object>()),
        Times.Once);
    }

    [Fact]
    public async Task GetByIdNotFoundTest()
    {
        _repositoryMock.Setup(r => r.GetById(1)).Returns<Animal>(null);

        var response = await _client.GetAsync("/animals/1");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        _repositoryMock.Verify(r => r.GetById(1), Times.Once);

        _loggerMock.Verify(x => x.Log(
            It.Is<LogLevel>(ll => ll == LogLevel.Warning),
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "GetById failed: the animal with id 1 was not found"
                && @type.Name == "FormattedLogValues"),
            It.IsAny<Exception>(),
            (Func<It.IsAnyType, Exception?, string>)It.IsAny<object>()),
        Times.Once);
    }

    [Fact]
    public async Task CreateSuccessTest()
    {
        var request = AutoFaker.Generate<AnimalRequest>();

        _repositoryMock.Setup(r => r.GetNextIdValue()).Returns(1);
        _repositoryMock.Setup(r => r.Create(It.Is<Animal>(r => r.Id == 1))).Returns(true);

        var response = await _client.PostAsJsonAsync("/animals", request);
        var content = await response.Content.ReadFromJsonWithEnumAsync<Animal>();

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        content!.Id.Should().Be(1);
        content.Name.Should().Be(request.Name);
        content.Species.Should().Be(request.Species);

        content.CreatedAt.Should()
            .BeCloseTo(content.UpdatedAt, TimeSpan.FromMilliseconds(100));

        _repositoryMock.Verify(r => r.GetNextIdValue(), Times.Once);
        _repositoryMock.Verify(r => r.Create(It.Is<Animal>(r => r.Id == 1)), Times.Once);

        _loggerMock.Verify(x => x.Log(
            It.Is<LogLevel>(ll => ll == LogLevel.Information),
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Create executed with id 1"
               && @type.Name == "FormattedLogValues"),
            It.IsAny<Exception>(),
            (Func<It.IsAnyType, Exception?, string>)It.IsAny<object>()),
        Times.Once);
    }

    [Fact]
    public async Task UpdateSuccessTest()
    {
        var request = AutoFaker.Generate<AnimalRequest>();

        _repositoryMock.Setup(r => r.Update(It.Is<int>(id => id == 1),
            It.IsAny<object>())).Returns(true);

        var response = await _client.PutAsJsonAsync("/animals/1", request);
        var content = await response.Content.ReadAsStringAsync();

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        content.Should().Be("Animal 1 updated");

        _repositoryMock.Verify(r => r.Update(It.Is<int>(id => id == 1),
            It.IsAny<object>()), Times.Once);

        _loggerMock.Verify(x => x.Log(
            It.Is<LogLevel>(ll => ll == LogLevel.Information),
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Update executed with id 1"
               && @type.Name == "FormattedLogValues"),
            It.IsAny<Exception>(),
            (Func<It.IsAnyType, Exception?, string>)It.IsAny<object>()),
        Times.Once);
    }

    [Fact]
    public async Task UpdateNotFoundTest()
    {
        var request = AutoFaker.Generate<AnimalRequest>();

        _repositoryMock.Setup(r => r.Update(It.Is<int>(id => id == 1),
            It.IsAny<object>())).Returns(false);

        var response = await _client.PutAsJsonAsync("/animals/1", request);
        var content = await response.Content.ReadAsStringAsync();

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        content.Should().Be("Animal not found");

        _repositoryMock.Verify(r => r.Update(It.Is<int>(id => id == 1),
            It.IsAny<object>()), Times.Once);

        _loggerMock.Verify(x => x.Log(
           It.Is<LogLevel>(ll => ll == LogLevel.Warning),
           It.IsAny<EventId>(),
           It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Update failed: The animal with id 1 was not found"
               && @type.Name == "FormattedLogValues"),
           It.IsAny<Exception>(),
           (Func<It.IsAnyType, Exception?, string>)It.IsAny<object>()),
       Times.Once);
    }

    [Fact]
    public async Task DeleteSuccessTest()
    {
        _repositoryMock.Setup(r => r.Delete(It.Is<int>(id => id == 1))).Returns(true);

        var response = await _client.DeleteAsync("/animals/1");

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        _repositoryMock.Verify(r => r.Delete(It.Is<int>(id => id == 1)), Times.Once);

        _loggerMock.Verify(x => x.Log(
            It.Is<LogLevel>(ll => ll == LogLevel.Information),
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Delete executed with id 1"
               && @type.Name == "FormattedLogValues"),
            It.IsAny<Exception>(),
            (Func<It.IsAnyType, Exception?, string>)It.IsAny<object>()),
        Times.Once);
    }

    [Fact]
    public async Task DeleteNotFoundTest()
    {
        _repositoryMock.Setup(r => r.Delete(It.Is<int>(id => id == 1))).Returns(false);

        var response = await _client.DeleteAsync("/animals/1");
        var content = await response.Content.ReadAsStringAsync();

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        content.Should().Be("Animal not found");

        _repositoryMock.Verify(r => r.Delete(It.Is<int>(id => id == 1)), Times.Once);

        _loggerMock.Verify(x => x.Log(
            It.Is<LogLevel>(ll => ll == LogLevel.Warning),
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Delete failed: The animal with id 1 was not found"
                && @type.Name == "FormattedLogValues"),
            It.IsAny<Exception>(),
            (Func<It.IsAnyType, Exception?, string>)It.IsAny<object>()),
        Times.Once);
    }

    [Fact]
    public async Task InternalServerErrorTests()
    {
        var responses = new List<HttpResponseMessage> {
            await _client.GetAsync("/animals"),
            await _client.GetAsync("/animals/1"),
            await _client.PostAsJsonAsync("/animals", new AnimalRequest()),
            await _client.PutAsJsonAsync("/animals/1", new AnimalRequest()),
            await _client.DeleteAsync("/animals/1")
        };

        foreach (var response in responses)
        {
            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        _repositoryMock.Verify(r => r.GetById(1), Times.Once);
        _repositoryMock.Verify(r => r.GetAll(), Times.Once);
        _repositoryMock.Verify(r => r.GetNextIdValue(), Times.Once);
        _repositoryMock.Verify(r => r.Update(It.IsAny<int>(), It.IsAny<object>()), Times.Once);
        _repositoryMock.Verify(r => r.Delete(It.IsAny<int>()), Times.Once);

        _loggerMock.Verify(x => x.Log(
            It.Is<LogLevel>(ll => ll == LogLevel.Error),
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((@object, @type) => @object.ToString().EndsWith("failed")
                && @type.Name == "FormattedLogValues"),
            It.IsAny<Exception>(),
            (Func<It.IsAnyType, Exception?, string>)It.IsAny<object>()),
        Times.AtLeastOnce);
    }
}
