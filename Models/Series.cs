using System;

namespace CallOfDutyLeague.Models
{
    public class Series
    {
        public long SeriesID { get; set; }
        public long EventID { get; set; }
        public string EventName { get; set; }
        public DateTimeOffset SeriesDate { get; set; }
        public long HomeTeamID { get; set; }
        public long AwayTeamID { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public byte BestOfGameNumber { get; set; }
        public string HomeTeamImageURL { get; set; }
        public string AwayTeamImageURL { get; set; }
    }
}
