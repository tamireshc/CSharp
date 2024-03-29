using Xunit;
using System;
using FluentAssertions;
using TrybeGames;
using Moq;

namespace TrybeGames.Test;

[Collection("Sequential")]
public class TestTrybeGamesDatabase
{
    [Theory(DisplayName = "Deve testar se GetGamesPlayedBy retorna jogos jogados pela pessoa jogadora corretamente.")]
    [MemberData(nameof(DataTestGetGamesPlayedBy))]
    public void TestGetGamesPlayedBy(TrybeGamesDatabase databaseEntry, int playerIdEntry, List<Game> expected)
    {
        var players = from playerSelect in databaseEntry.Players
                      where playerSelect.Id == playerIdEntry
                      select playerSelect;

        var playerSelectResult = new List<Player>();

        foreach (var player in players)
        {
            var playerS = new Player { Name = player.Name, Id = player.Id };
            playerSelectResult.Add(playerS);
        }

        var result = databaseEntry.GetGamesPlayedBy(playerSelectResult[0]);
        result.Should().BeEquivalentTo(expected);
    }

    public static TheoryData<TrybeGamesDatabase, int, List<Game>> DataTestGetGamesPlayedBy => new TheoryData<TrybeGamesDatabase, int, List<Game>>
    {
        {
            new TrybeGamesDatabase
            {
                Games = new List<Game>
                {
                    new Game
                    {
                        Id = 1,
                        Name = "Teste",
                        DeveloperStudio = 1,
                        Players = new List<int> { 1 }
                    }
                },
                GameStudios = new List<GameStudio>
                {
                    new GameStudio
                    {
                        Id = 1,
                        Name = "Teste"
                    }
                },
                Players = new List<Player>
                {
                    new Player
                    {
                        Id = 1,
                        Name = "Teste",
                        GamesOwned = new List<int> { 1 }
                    }
                }
            },
            1,
            new List<Game>
            {
                new Game
                {
                    Id = 1,
                    Name = "Teste",
                    DeveloperStudio = 1,
                    Players = new List<int> { 1 }
                }
            }
        }
    };

    [Theory(DisplayName = "Deve testar se GetGamesOwnedBy retorna jogos da pessoa jogadora corretamente.")]
    [MemberData(nameof(DataTestGetGamesOwnedBy))]
    public void TestGetGamesOwnedBy(TrybeGamesDatabase databaseEntry, int playerIdEntry, List<Game> expected)
    {

        var players = from playerSelect in databaseEntry.Players
                      where playerSelect.Id == playerIdEntry
                      select playerSelect;

        var playerSelectResult = new List<Player>();

        foreach (var player in players)
        {
            var playerS = new Player { Name = player.Name, Id = player.Id };
            playerSelectResult.Add(playerS);
        }

        var result = databaseEntry.GetGamesOwnedBy(playerSelectResult[0]);
        result.Should().BeEquivalentTo(expected);
    }

    public static TheoryData<TrybeGamesDatabase, int, List<Game>> DataTestGetGamesOwnedBy => new TheoryData<TrybeGamesDatabase, int, List<Game>>
    {
        {
            new TrybeGamesDatabase
            {
                Games = new List<Game>
                {
                    new Game
                    {
                        Id = 1,
                        Name = "Teste",
                        DeveloperStudio = 1,
                        Players = new List<int> { 1 }
                    }
                },
                GameStudios = new List<GameStudio>
                {
                    new GameStudio
                    {
                        Id = 1,
                        Name = "Teste"
                    }
                },
                Players = new List<Player>
                {
                    new Player
                    {
                        Id = 1,
                        Name = "Teste",
                        GamesOwned = new List<int> { 1 }
                    }
                }
            },
            1,
            new List<Game>
            {
                new Game
                {
                    Id = 1,
                    Name = "Teste",
                    DeveloperStudio = 1,
                    Players = new List<int> { 1 }
                }
            }
        }
    };

    [Theory(DisplayName = "Deve testar se GetGamesDevelopedBy retorna jogos desenvolvidos pelo estúdio corretamente.")]
    [MemberData(nameof(DataTestGetGamesDevelopedBy))]
    public void TestGetGamesDevelopedBy(TrybeGamesDatabase databaseEntry, int gameStudioIdEntry, List<Game> expected)
    {
        var gameStudio = from gamesstudio in databaseEntry.GameStudios
                         where gamesstudio.Id == gameStudioIdEntry
                         select gamesstudio;

        var gameStudioResult = new List<GameStudio>();

        foreach (var gameS in gameStudio)
        {
            var gameStudiox = new GameStudio { Name = gameS.Name, Id = gameS.Id, CreatedAt = gameS.CreatedAt };
            gameStudioResult.Add(gameStudiox);
        }

        var result = databaseEntry.GetGamesDevelopedBy(gameStudioResult[0]);
        result.Should().BeEquivalentTo(expected);

    }

    public static TheoryData<TrybeGamesDatabase, int, List<Game>> DataTestGetGamesDevelopedBy => new TheoryData<TrybeGamesDatabase, int, List<Game>>
    {
        {
            new TrybeGamesDatabase
            {
                Games = new List<Game>
                {
                    new Game
                    {
                        Id = 1,
                        Name = "Teste",
                        DeveloperStudio = 1,
                        Players = new List<int> { 1 }
                    }
                },
                GameStudios = new List<GameStudio>
                {
                    new GameStudio
                    {
                        Id = 1,
                        Name = "Teste"
                    }
                },
                Players = new List<Player>
                {
                    new Player
                    {
                        Id = 1,
                        Name = "Teste",
                        GamesOwned = new List<int> { 1 }
                    }
                }
            },
            1,
            new List<Game>
            {
                new Game
                {
                    Id = 1,
                    Name = "Teste",
                    DeveloperStudio = 1,
                    Players = new List<int> { 1 }
                }
            }
        }
    };
}
