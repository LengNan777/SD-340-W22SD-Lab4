using System;
using System.Collections.Generic;

namespace SD_340_W22SD_Lab4.Models
{
    public partial class Stop
    {
        public Stop()
        {
            ScheduledStops = new HashSet<ScheduledStop>();
        }

        public int Number { get; set; }
        public string Street { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Direction { get; set; } = null!;

        public virtual ICollection<ScheduledStop> ScheduledStops { get; set; }
    }
}
