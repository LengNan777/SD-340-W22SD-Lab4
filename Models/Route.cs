using System;
using System.Collections.Generic;

namespace SD_340_W22SD_Lab4.Models
{
    public partial class Route
    {
        public Route()
        {
            ScheduledStops = new HashSet<ScheduledStop>();
        }

        public int Number { get; set; }
        public string Name { get; set; } = null!;
        public string Direction { get; set; } = null!;
        public bool RampAccessible { get; set; }
        public bool BicycleAccessible { get; set; }

        public virtual ICollection<ScheduledStop> ScheduledStops { get; set; }
    }
}
