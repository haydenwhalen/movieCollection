using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieCollection.Models
{
    public class Movie
    {
        // Primary key for the database table
        [Key]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        // Required field for the category of the movie
        [Required(ErrorMessage = "Category is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Required field for the movie title
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        // Required field for the release year of the movie
        [Required(ErrorMessage = "Year is required")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be no lower than 1888")]
        public int Year { get; set; }

        // Director Field
        public string? Director { get; set; }


        // Required field for the movie rating (e.g., G, PG, PG-13, R)
        
        public string? Rating { get; set; }

        // Optional field indicating whether the movie is edited.
        // Made nullable (bool?) because it is not required.
        [Required(ErrorMessage = "Edit ")]
        public bool Edited { get; set; }

        // Optional field to record who the movie is lent to
        public string? LentTo { get; set; }

        // Optional field for notes about the movie, limited to 25 characters
        [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters")]
        public string? Notes { get; set; }
        
        [Required]
        public string CopiedToPlex { get; set; } = "No";

    }
}

