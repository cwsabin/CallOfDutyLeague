using CallOfDutyLeague.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Repositories
{
    public interface ISeriesRepository
    {
        public Task<List<Series>> GetSeriesScheduleByEventAsync(long eventID);
    }
    public class SeriesRepository : ISeriesRepository
    {
        public async Task<List<Series>> GetSeriesScheduleByEventAsync(long eventID)
        {
            using (var con = new SqlConnection(Constants.ConnectionString))
            {
                var parameters = new { eventID };
                return (await con.QueryAsync<Series>($@"SELECT
                        series.SeriesID,
                        series.SeriesDate,
                        series.HomeTeamID,
                        homeTeam.TeamName AS HomeTeam,
                        series.AwayTeamID,
                        awayTeam.TeamName AS AwayTeam,
                        series.BestOfGameNumber,
                        event.EventID,
                        event.EventName,
                        event.EventType,
                        homeImage.ImageURL AS HomeTeamImageURL,
                        awayImage.ImageURL AS AwayTeamImageURL
                    FROM tblSeries series (NOLOCK)
                    JOIN tblEvent event (NOLOCK) on event.EventID = series.EventID
                    JOIN tblSeasonTeam homeSeasonTeam (NOLOCK) ON homeSeasonTeam.SeasonTeamID = series.HomeTeamID
                    JOIN tblTeamImage homeImage (NOLOCK) ON homeImage.SeasonTeamID = homeSeasonTeam.SeasonTeamID
                    JOIN tblSeasonTeam awaySeasonTeam(NOLOCK) ON awaySeasonTeam.SeasonTeamID = series.AwayTeamID
                    JOIN tblTeamImage awayImage (NOLOCK) ON awayImage.SeasonTeamID = awaySeasonTeam.SeasonTeamID
                    JOIN tblTeam homeTeam (NOLOCK) ON homeSeasonTeam.TeamID = homeTeam.TeamID
                    JOIN tblTeam awayTeam (NOLOCK) ON awaySeasonTeam.TeamID = awayTeam.TeamID
                    WHERE series.EventID = @eventID
                    ORDER BY series.SeriesDate", parameters)).ToList();
            }
        }
    }
}
