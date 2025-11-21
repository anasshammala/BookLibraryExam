using System.ComponentModel.DataAnnotations;

namespace BookLibraryExam.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [RegularExpression(@"\d{3}-\d{10}", ErrorMessage = "ISBN must be in the format 000-0000000000")]
        public string ISBN { get; set; }

        [Range(1800, 2025)]
        [Display(Name = "Publication Year")]
        public int PublicationYear { get; set; }
    }
}

