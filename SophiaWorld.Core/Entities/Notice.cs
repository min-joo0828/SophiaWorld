using System.ComponentModel.DataAnnotations;

namespace SophiaWorld.Core.Entities
{
    public class Notice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}