using System.Collections.Generic;

namespace CallOfDutyLeague.Models
{
    public class SeriesDetail
    {
        public long SeriesDetailID { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public List<SeriesMap> SeriesMaps { get; set; }
    }
}
