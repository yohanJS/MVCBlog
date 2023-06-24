using System.ComponentModel.DataAnnotations;

namespace MVCBlog.Models
{
    public class Blog
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; } = null;
        [Required]
        public string? Author { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public string? Category { get; set; }
        public DateTime CreatedDate { get; set;} = DateTime.Now;

    }
}
