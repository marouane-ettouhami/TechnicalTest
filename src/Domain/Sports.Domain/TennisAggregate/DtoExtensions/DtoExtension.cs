using Sports.Domain.TennisAggregate.ReadDtos;
using Sports.Domain.TennisAggregate.Entities;
using System.Collections.Generic;

namespace Sports.Domain.TennisAggregate.DtoExtensions
{
    public static class DtoExtension
    {
        public static List<Player> ToPLayers(this List<PlayerReadDto> playerDtos)
        {
            var players = new List<Player>();
            foreach (var playerDto in playerDtos)
            {
                players.Add(playerDto.ToPlayer());
            }

            return players;
        }

        private static Player ToPlayer(this PlayerReadDto playerDto)
        {
            return new Player
            {
                Id = playerDto.Id,
                Country = playerDto.Country.ToCountry(),
                //CountryCode = playerDto.CountryCode,
                FirstName = playerDto.FirstName,
                LastName = playerDto.LastName,
                ShortName = playerDto.ShortName,
                Sex = playerDto.Sex,
                Picture = playerDto.Picture,
                Data = playerDto.Data.ToData()
            };
        }

        public static IEnumerable<Country> ToCountries(this IEnumerable<CountryReadDto> countryDtos)
        {
            var countries = new List<Country>();
            foreach (var countryDto in countryDtos)
            {
                countries.Add(countryDto.ToCountry());
            }

            return countries;
        }

        private static Country ToCountry(this CountryReadDto countryDto)
        {
            return new Country
            {
                Code = countryDto.Code,
                Picture = countryDto.Picture,
            };
        }

            private static Data ToData(this DataReadDto dataDto)
        {
            return new Data
            {
                //DataId = dataDto.DataId,
                Rank = dataDto.Rank,
                Points = dataDto.Points,
                Weight = dataDto.Weight,
                Height = dataDto.Height,
                Age = dataDto.Age,
                Last = dataDto.Last.ToLastGames()
            };

        }
        private static List<LastGames> ToLastGames(this List<int> gameList)
        {
            var lastGames = new List<LastGames>();
            foreach (var game in gameList)
            {
                lastGames.Add(new LastGames { Result = (byte)game });
            }

            return lastGames;
        }
    }
}
