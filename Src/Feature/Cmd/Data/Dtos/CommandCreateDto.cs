using System.ComponentModel.DataAnnotations;

namespace Commander.Src.Feature.Cmd.Data.Dtos
{
    public class CommandCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}