using SensorData.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensorData.Models
{
    public class Measurement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeasurementId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(20)]
        public string SensorId { get; set; }

        [Required]
        public int Value1 { get; set; }

        [Required]
        public int Value2 { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value3 { get; set; }

        // Navigation property to Sensor
        [ForeignKey("SensorId")]
        public virtual Sensor Sensor { get; set; }
    }
}
