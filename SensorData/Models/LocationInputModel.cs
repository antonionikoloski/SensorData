using System.ComponentModel.DataAnnotations;

namespace SensorData.Models
{
    public class LocationInputModel
    {
        [Required]
        [StringLength(20)]
        public string LocationName { get; set; }
    }
}

