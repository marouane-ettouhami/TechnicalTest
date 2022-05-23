using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sports.Domain.TennisAggregate.Entities
{
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string ShortName { get; set; }

        [Required]
        public char Sex { get; set; }
        [Required]
        [MaxLength(3)]
        public string CountryCode { get; set; }
        public Country Country { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public virtual Data Data { get; set; }
    }
}
