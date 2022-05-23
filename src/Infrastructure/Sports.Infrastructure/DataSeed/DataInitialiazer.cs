using Sports.Domain.TennisAggregate.Abstractions;
using Sports.Domain.TennisAggregate.ReadDtos;
using Sports.Domain.TennisAggregate.DtoExtensions;
using Sports.Infrastructure.TennisRepository.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Sports.Domain.Exceptions;

namespace Sports.Infrastructure.DataSeed
{
    public class DataInitialiazer : IDataInitializer
    {
        private readonly TennisDbContext _dbContext;
        public DataInitialiazer(TennisDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void SeedData()
        {
            try
            {
                if (!_dbContext.Players.Any())
                {
                    // Read Data From Json File
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    using (StreamReader reader = new StreamReader(Constants.DataFilePath + Path.DirectorySeparatorChar + Constants.DataFileName))
                    {
                        string json = reader.ReadToEnd();
                        var playersDto = JsonSerializer.Deserialize<List<PlayerReadDto>>(json, options);

                        // Seed Data to Database
                        var countries = playersDto.Select(p => p.Country).GroupBy(c => c.Code).Select(c => c.FirstOrDefault()).ToCountries();
                        _dbContext.Countries.AddRange(countries);

                        var players = playersDto.ToPLayers();
                        foreach (var player in players)
                        {
                            player.CountryCode = player.Country.Code;
                            player.Country = countries.FirstOrDefault(c => c.Code == player.CountryCode);
                            _dbContext.Players.Add(player);
                        }

                        _dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataSeedException("Error while reading from Json file and seeding to database", ex);
            }
        }
    }
}
