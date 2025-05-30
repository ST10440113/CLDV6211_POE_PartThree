using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CLDV6211_POE_PartThree.Models;

namespace CLDV6211_POE_PartThree.Data
{
    public class CLDV6211_POE_PartThreeContext : DbContext
    {
        public CLDV6211_POE_PartThreeContext (DbContextOptions<CLDV6211_POE_PartThreeContext> options)
            : base(options)
        {
        }

        public DbSet<CLDV6211_POE_PartThree.Models.Event> Event { get; set; } = default!;
        public DbSet<CLDV6211_POE_PartThree.Models.Venue> Venue { get; set; } = default!;
        public DbSet<CLDV6211_POE_PartThree.Models.Booking> Booking { get; set; } = default!;
    }
}
