using System.ComponentModel.DataAnnotations;

namespace CTRLightsPublicAPI.Data.Models
{
    public class AdminUsers
    {
        //Key value
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [StringLength(16)]
        public string Key { get; set; } = string.Empty;
    }
}
