using System;
using System.ComponentModel.DataAnnotations;

namespace RatingApp.Models
{
    public class Rating
    {
        public int Id { get; set; }

        [Range(2, 5)]
        public int Value { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5)]
        public string StudentId { get; set; }

        [Required]
        public string StudentName { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
