using System.ComponentModel.DataAnnotations;

namespace MVCBlog.Models
{
    public class Blog
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Title must start with an uppercase letter and can only contain letters and spaces.")]
        [StringLength(60, MinimumLength = 5)]
        public string? Title { get; set; }

        public string? Description { get; set; } = null;

        [Required]
        public string? Author { get; set; }

        public string? Content { get; set; }

        [Required]
        public string? Category { get; set; }
        
        //The DataType attribute on CreatedDate specifies the type of the data (Date). With this attribute:
        [Display(Name = "Created Date"), DataType(DataType.Date)]
        public DateTime CreatedDate { get; set;} = DateTime.Now;

    }
}
