using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieCollection.Models
{
    public class Movie
    {
        // Primary key for the database table
        [Key]
        public int MovieId { get; set; }

        // Required field for the category of the movie
        [Required(ErrorMessage = "Category is required")]
        [Column("CategoryId")]
        public string Category { get; set; }

        // Required field for the movie title
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        // Required field for the release year of the movie
        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        // Required field for the director of the movie
        
        public string? Director { get; set; }


        // Required field for the movie rating (e.g., G, PG, PG-13, R)
        [Required(ErrorMessage = "Rating is required")]
        public string Rating { get; set; }

        // Optional field indicating whether the movie is edited.
        // Made nullable (bool?) because it is not required.
        public bool? Edited { get; set; }

        // Optional field to record who the movie is lent to
        public string LentTo { get; set; }

        // Optional field for notes about the movie, limited to 25 characters
        [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters")]
        public string Notes { get; set; }
    }
}

