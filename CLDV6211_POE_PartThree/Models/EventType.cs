using System.ComponentModel.DataAnnotations;

namespace CLDV6211_POE_PartThree.Models
{
    public class EventType
    {
        [Key]
        public int EventTypeId { get; set; }

        [Display(Name = "Event Type Name")]
        public required string EventTypeName { get; set; }
    }
}

