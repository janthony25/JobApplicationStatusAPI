using System.ComponentModel.DataAnnotations;

namespace ApplicationStatusAPI.Models.Dto
{
    public class AddJobApplicationDto
    {
        [Required(ErrorMessage = "Job link is required.")]
        public string JobLink { get; set; }

        [Required(ErrorMessage = "Company name is required.")]
        [MaxLength(50)]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Job title is required.")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public int LocationId { get; set; }

        public int SubmissionStatusId { get; set; }

        public int ApplicationStatusId { get; set; }
        public int SourceId { get; set; }   
    }
}
