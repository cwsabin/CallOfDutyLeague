namespace CallOfDutyLeague.Models
{
    public class SeasonTeam
    {
        public long SeasonID { get; set; }
        public Season Season { get; set; }
        public long TeamID { get; set; }
        public Team Team { get; set; }
    }
}
