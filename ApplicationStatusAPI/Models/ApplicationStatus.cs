using System.ComponentModel.DataAnnotations;

namespace ApplicationStatusAPI.Models
{
    public class ApplicationStatus
    {
        [Key]
        public int ApplicationStatusId { get; set; }
        public string ApplicationStatusName { get; set; }   
    }
}
