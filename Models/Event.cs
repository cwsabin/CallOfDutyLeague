using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Models
{
    public class Event
    {
        public long EventID { get; set; }
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
