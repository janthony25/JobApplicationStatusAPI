using System.ComponentModel.DataAnnotations;

namespace ApplicationStatusAPI.Models
{
    public class JobApplication
    {
        [Key]
        public int JobApplicationId { get; set; }

        [Required]
        public string JobLink { get; set; }

        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(50)]
        public string JobTitle { get; set; }
        public DateTime DateSubmitted { get; set; } = DateTime.Now;
        public DateTime? DateEdited { get; set; }

        // Location
        public int LocationId { get; set; }
        public Location Location { get; set; }

    }
}
