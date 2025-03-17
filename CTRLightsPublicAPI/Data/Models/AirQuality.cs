using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTRLightsPublicAPI.Data.Models
{
    public class AirQuality
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        [ForeignKey(nameof(EspDevice))]
        public int EspDeviceId { get; set; }
        public EspDevice EspDevice { get; set; }
    }
}
