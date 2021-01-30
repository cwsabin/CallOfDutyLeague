using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Models
{
    public class TeamStanding
    {
        public long SeasonTeamID { get; set; }
        public string TeamName { get; set; }
        public byte Wins { get; set; }
        public byte Losses { get; set; }
        public byte MapWins { get; set; }
        public byte MapLosses { get; set; }
    }
}
