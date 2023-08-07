using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Record
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        public string Field { get; set; }
    }
}