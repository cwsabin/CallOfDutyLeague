namespace CallOfDutyLeague.Models
{
    public class PlayerMap
    {
        public long PlayerSeasonMapID { get; set; }
        public long PlayerSeasonTeamID { get; set; }
        public string TeamName { get; set; }
        public string GamerName { get; set; }
        public long SeriesMapID { get; set; }
        public byte Kills { get; set; }
        public byte Deaths { get; set; }
        public short Damage { get; set; }
    }
}
