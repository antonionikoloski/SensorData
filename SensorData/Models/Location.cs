using SensorData.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensorData.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }

        [Required]
        [StringLength(20)]
        public string LocationName { get; set; }

        // Navigation property to Sensors
        public virtual ICollection<Sensor> Sensors { get; set; }
    }
}
