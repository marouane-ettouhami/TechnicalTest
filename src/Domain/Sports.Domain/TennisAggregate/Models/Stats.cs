using Sports.Domain.TennisAggregate.Entities;

namespace Sports.Domain.TennisAggregate.Models
{
    public class Stats
    {
        public Country CountryWithMostWins { get; set; }
        public double BMI { get; set; }
        public double MedianHeight { get; set; }
    }
}
