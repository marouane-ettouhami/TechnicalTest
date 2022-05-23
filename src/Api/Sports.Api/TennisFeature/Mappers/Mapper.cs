using Sports.Domain.TennisAggregate.ReadDtos;
using Sports.Domain.TennisAggregate.Entities;
using System.Collections.Generic;

namespace Sports.Api.TennisFeature.Mappers
{
    public static class Mapper
    {
        public static List<PlayerReadDto> ToPLayerDtos(List<Player> players)
        {
            var playerDtos = new List<PlayerReadDto>();
            foreach (var player in players)
            {
                playerDtos.Add(player.ToPlayerDto());
            }

            return playerDtos;
        }

        public static PlayerReadDto ToPlayerDto(this Player player)
        {
            return new PlayerReadDto
            {
                Id = player.Id,
                Country = player.Country.ToCountryDto(),
                FirstName = player.FirstName,
                LastName = player.LastName,
                ShortName = player.ShortName,
                Sex = player.Sex,
                Picture = player.Picture,
                Data = player.Data.ToDataDto()
            };
        }

        private static CountryReadDto ToCountryDto(this Country country)
        {
            return new CountryReadDto
            {
                Code = country.Code,
                Picture = country.Picture,
            };
        }

        private static DataReadDto ToDataDto(this Data data)
        {
            return new DataReadDto
            {
                Rank = data.Rank,
                Points = data.Points,
                Weight = data.Weight,
                Height = data.Height,
                Age = data.Age,
                Last = data.Last.ToLastGamesDto()
            };

        }
        private static List<int> ToLastGamesDto(this List<LastGames> lastGames)
        {
            var gamesPlayed = new List<int>();
            foreach (var game in lastGames)
            {
                gamesPlayed.Add(game.Result);
            }
            return gamesPlayed;
        }
    }
}
