using SensorData.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensorData.Models
{
    public class Sensor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        // Navigation property to Location
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        // Navigation property to Measurements
        public virtual ICollection<Measurement> Measurements { get; set; }
    }
}
