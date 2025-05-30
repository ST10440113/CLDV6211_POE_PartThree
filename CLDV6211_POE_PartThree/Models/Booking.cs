using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CLDV6211_POE_PartThree.Models
{
    public class Booking
    {

        [Key] public int BookingId { get; set; }


        public int EventId { get; set; }
        [ForeignKey("EventId")]

        [ValidateNever]
        public Event Event { get; set; }



        public int VenueId { get; set; }
        [ForeignKey("VenueId")]
        [ValidateNever]
        public Venue Venue { get; set; }




        [Display(Name = "Start date of booking")]
        [DataType(DataType.Date)] public DateTime BookingStartDate { get; set; }

        [Display(Name = "End date of booking")]
        [DataType(DataType.Date)] public DateTime BookingEndDate { get; set; }

    }
}

