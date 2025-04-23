using System.ComponentModel.DataAnnotations;

namespace CTRLightsPublicAPI.Data.Models
{
    public class TrafficLights
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool FreeLaneStatus { get; set; }

        [Required]
        public TimeSpan TimeSpan { get; set; }

        [Required]
        public int Lane { get; set; }

        [Required]
        public char LightStatus { get; set; }

        [Required]
        public string Busyness { get; set; } = "L"; //L - low, M - mid, H - high
    }
}
