namespace TrybeGames;

public class TrybeGamesDatabase
{
    public List<Game> Games = new List<Game>();

    public List<GameStudio> GameStudios = new List<GameStudio>();

    public List<Player> Players = new List<Player>();

    public List<Game> GetGamesDevelopedBy(GameStudio gameStudio)
    {
        // implementar
        var gamesForStudio = from game in Games
                             where game.DeveloperStudio == gameStudio.Id
                             select game;
        return gamesForStudio.ToList();
    }

    public List<Game> GetGamesPlayedBy(Player player)
    {
        // Implementar
        var gamesPlayedByPlayer = from game in Games
                                  where game.Players.Contains(player.Id)
                                  select game;
        return gamesPlayedByPlayer.ToList();
    }

    public List<Game> GetGamesOwnedBy(Player playerEntry)
    {
        // var gamePlayerHas = new List<Game>();

        // foreach (var idGame in playerEntry.GamesOwned)
        // {
        //     var gameById = from game in Games
        //                    where game.Id == idGame
        //                    select game;

        //     gamePlayerHas.Add(gameById.ToList()[0]);
        // }
        // return gamePlayerHas;

        var gamePlayerHas = from game in Games
                            where game.Players.Contains(playerEntry.Id)
                            select game;

        return gamePlayerHas.ToList();
    }
}
