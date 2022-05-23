using System.ComponentModel.DataAnnotations;

namespace Sports.Domain.TennisAggregate.Entities
{
    public class LastGames
    {
        [Key]
        public int GameId { get; set; }
        public byte Result { get; set; }
        public int DataId { get; set; }
        public virtual Data Data { get; set; }
    }
}
