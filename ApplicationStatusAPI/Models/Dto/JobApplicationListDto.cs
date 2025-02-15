using System.ComponentModel.DataAnnotations;

namespace ApplicationStatusAPI.Models.Dto
{
    public class JobApplicationListDto
    {
        public int JobApplicationId { get; set; }
        public string JobLink { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string LocationName { get; set; }
        public string SubmissionStatusName { get; set; }
        public string ApplicationStatusName { get; set; }
        public string SourceName { get; set; }  
        public DateTime? DateEdited { get; set; }

    }
}
