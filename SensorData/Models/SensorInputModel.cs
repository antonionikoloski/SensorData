using System.ComponentModel.DataAnnotations;

namespace SensorData.Models
{
    public class SensorInputModel
    {
        [StringLength(20)]
        public string SensorId { get; set; }

        [Required]
        [StringLength(100)]
        public string SensorName { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime ActivationDate { get; set; }
    }
}
