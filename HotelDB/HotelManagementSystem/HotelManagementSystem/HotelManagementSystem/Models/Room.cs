using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        [StringLength(10)]
        public string RoomNumber { get; set; }

        [ForeignKey("RoomType")]
        public int RoomTypeId { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public RoomType RoomType { get; set; }
    }
}
