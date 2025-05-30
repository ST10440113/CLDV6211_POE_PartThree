using System.ComponentModel.DataAnnotations;

namespace CLDV6211_POE_PartThree.Models
{
    public class Event
    {


        [Key]
        public int EventId { get; set; }

        [Display(Name = "Event Name")]
        public required string EventName { get; set; }

        public string? Description { get; set; }

        [Display(Name = "Date of Event")]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }



    }
}
