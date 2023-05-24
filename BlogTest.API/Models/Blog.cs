using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlogTest.API.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Contents { get; set; } = string.Empty;
        public DateTimeOffset Timestamp { get; set; } = (DateTimeOffset)DateTime.UtcNow;

        [Required]
        public int CategoryId { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }
    }
}