using Commander.Src.Core.Generic.LocalData;
using System.ComponentModel.DataAnnotations;

namespace Commander.Src.Feature.Cmd.Domain.Entity
{
    public class Command: IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}