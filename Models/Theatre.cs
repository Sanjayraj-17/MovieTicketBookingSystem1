using System.ComponentModel.DataAnnotations;

namespace MovieTicketBooking.Models
{
    public class Theatre
    {
        public int TheatreId { get; set; }

        [Required]
        [StringLength(150)]
        public string? Name { get; set; }

        [Required]
        [StringLength(200)]
        public string? Loction { get; set; }



     
    }
}
