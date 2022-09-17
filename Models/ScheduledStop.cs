using System;
using System.Collections.Generic;

namespace SD_340_W22SD_Lab4.Models
{
    public partial class ScheduledStop
    {
        public int Id { get; set; }
        public int StopNumber { get; set; }
        public int RoutenNumber { get; set; }
        public DateTime ScheduledArrival { get; set; }

        public virtual Route RoutenNumberNavigation { get; set; } = null!;
        public virtual Stop StopNumberNavigation { get; set; } = null!;
    }
}
