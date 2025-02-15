using System.ComponentModel.DataAnnotations;

namespace ApplicationStatusAPI.Models.Dto
{
    public class AddJobApplicationDto
    {
        [Required]
        public string JobLink { get; set; }

        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public int LocationId { get; set; }
        public int SubmissionStatusId { get; set; }
        public int ApplicationStatusId { get; set; }
    }
}
