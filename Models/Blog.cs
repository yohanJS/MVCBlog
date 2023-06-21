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
        public string? Description { get; set; } = null;
        [Required]
        public string? Author { get; set; }
        public string? Content { get; set; }

        //The DataType attribute on CreatedDate specifies the type of the data (Date). With this attribute:
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set;} = DateTime.Now;

    }
}
