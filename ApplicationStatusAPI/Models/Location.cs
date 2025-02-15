using System.ComponentModel.DataAnnotations;

namespace ApplicationStatusAPI.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Required]
        public string LocationName { get; set; }

    }
}
