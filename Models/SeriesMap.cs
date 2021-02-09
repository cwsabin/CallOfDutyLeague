using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Models
{
    public class SeriesMap
    {
        public long SeriesMapID { get; set; }
        public long MapID { get; set; }
        public string MapName { get; set; }
        public long GameModeID { get; set; }
        public string GameMode { get; set; }
        public byte HomeTeamScore { get; set; }
        public byte AwayTeamScore { get; set; }
        public byte MapNumber { get; set; }
        public List<PlayerMap> PlayerMaps { get; set; }
    }
}
