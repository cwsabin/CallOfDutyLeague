using CallOfDutyLeague.Models;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Repositories
{
    public interface ISeriesDetailRepository
    {
        public Task<SeriesDetail> GetSeriesDetails(long seriesID);
    }
    public class SeriesDetailRepository : ISeriesDetailRepository
    {
        public async Task<SeriesDetail> GetSeriesDetails(long seriesID)
        {
            using (var con = new SqlConnection(Constants.ConnectionString))
            {
                var parameters = new { seriesID };
                var seriesDetail = await con.QueryFirstAsync<SeriesDetail>(@$"SELECT
	                series.SeriesID,
	                homeTeam.TeamName AS HomeTeamName,
	                awayTeam.TeamName AS AwayTeamName
                FROM tblSeries series (NOLOCK)
                JOIN tblSeasonTeam homeSeasonTeam (NOLOCK) ON homeSeasonTeam.SeasonTeamID = series.HomeTeamID
                JOIN tblTeam homeTeam (NOLOCK) ON homeTeam.TeamID = homeSeasonTeam.TeamID
                JOIN tblSeasonTeam awaySeasonTeam (NOLOCK) ON awaySeasonTeam.SeasonTeamID = series.AwayTeamID
                JOIN tblTeam awayTeam (NOLOCK) ON awayTeam.TeamID = awaySeasonTeam.TeamID
                WHERE series.SeriesID = @seriesID", parameters);

                seriesDetail.SeriesMaps = (await con.QueryAsync<SeriesMap>($@"SELECT
	                seriesMap.SeriesMapID,
	                seriesMap.MapID,
	                map.MapName,
	                seriesMap.GameModeID,
	                mode.GameMode,
	                seriesMap.AwayTeamScore,
	                seriesMap.HomeTeamScore,
	                seriesMap.MapNumber
                FROM tblSeriesMap seriesMap (NOLOCK)
                JOIN tblMap map (NOLOCK) ON map.MapID = seriesMap.MapID
                JOIN tblGameMode mode (NOLOCK) ON mode.GameModeID = seriesMap.GameModeID
                WHERE seriesMap.SeriesID = @seriesID
                ORDER BY seriesMap.MapNumber", parameters)).ToList();

                return seriesDetail;
            }
        }
    }
}
