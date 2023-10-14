using System;
using System.Collections.Generic;

namespace HomeScheduler.Data.Entity
{
    public partial class Availability
    {
        public int AvailabilityId { get; set; }
        public int UserId { get; set; }
        public bool Available { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; } = null!;
        public DateTime UpdatedDate { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
