using Sports.Domain.TennisAggregate.Entities;
using System.Collections.Generic;

namespace Sports.Tests.Mock.Provider.TennisAggregate
{
    public static class TennisProvider
    {
        public static List<Player> GetPlayers()
        {
            return new List<Player> { GetPlayer() };
        }

        public static Player GetPlayer()
        {
            return new Player
            {
                Id = 1,
                CountryCode = GetCountry().Code,
                Country = GetCountry(),
                FirstName = "Gael",
                LastName = "Monfils",
                Sex = 'M',
                ShortName = "G.Monf",
                Picture = "Picture",
                Data = GetData(),
            };
        }
        public static Country GetCountry()
        {
            return new Country
            {
                Code = "FRA",
                Picture = "Picture"
            };
        }

        public static Data GetData()
        {
            return new Data
            {
                DataId = 1,
                Rank = 2,
                Points = 2500,
                Weight = 70000,
                Height = 185,
                Age = 34,
                Last = new List<LastGames> { GetLastGame() }
            };
        }

        public static LastGames GetLastGame()
        {
            return new LastGames
            {
                GameId = 1,
                Result = 1,
                Data = GetData(),
                DataId = GetData().DataId
            };
        }
    }
}
