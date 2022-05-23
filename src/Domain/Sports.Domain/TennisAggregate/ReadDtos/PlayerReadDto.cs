namespace Sports.Domain.TennisAggregate.ReadDtos
{
    public class PlayerReadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortName { get; set; }
        public char Sex { get; set; }
        public CountryReadDto Country { get; set; }
        public string Picture { get; set; }
        public DataReadDto Data { get; set; }
    }
}
