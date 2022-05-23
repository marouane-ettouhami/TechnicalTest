using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sports.Domain.TennisAggregate.Entities
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(3)]
        public string Code { get; set; }
        public string Picture { get; set; } 
    }
}
