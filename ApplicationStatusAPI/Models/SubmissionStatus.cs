using System.ComponentModel.DataAnnotations;

namespace ApplicationStatusAPI.Models
{
    public class SubmissionStatus
    {

        [Key]
        public int SubmissionStatusId { get; set; }

        [Required]
        public string SubmissionStatusName { get; set; }        
    }
}
