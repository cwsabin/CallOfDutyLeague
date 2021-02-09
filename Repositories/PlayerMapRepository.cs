using CallOfDutyLeague.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Repositories
{
    public interface IPlayerMapRepository
    {
        public Task<List<PlayerMap>> GetPlayerMapsAsync(long seriesMapID);
    }
    public class PlayerMapRepository : IPlayerMapRepository
    {
        public async Task<List<PlayerMap>> GetPlayerMapsAsync(long seriesMapID)
        {
            using (var con = new SqlConnection(Constants.ConnectionString))
            {
                var parameters = new { seriesMapID };

                return (await con.QueryAsync<PlayerMap>($@"SELECT
	                playerSeriesMap.PlayerSeriesMapID,
	                playerSeriesMap.PlayerSeasonTeamID,
	                playerSeriesMap.SeriesMapID,
	                playerSeriesMap.Kills,
	                playerSeriesMap.Deaths,
	                playerSeriesMap.Damage,
	                team.TeamName,
	                player.GamerName
                FROM tblPlayerSeriesMap playerSeriesMap (NOLOCK)
                JOIN tblPlayerSeasonTeam playerSeasonTeam (NOLOCK) ON playerSeasonTeam.PlayerSeasonTeamID = playerSeriesMap.PlayerSeasonTeamID
                JOIN tblPlayer player (NOLOCK) ON playerSeasonTeam.PlayerID = player.PlayerID
                JOIN tblSeasonTeam seasonTeam (NOLOCK) ON playerSeasonTeam.SeasonTeamID = seasonTeam.SeasonTeamID
                JOIN tblTeam team (NOLOCK) ON team.TeamID = seasonTeam.TeamID
                JOIN tblSeriesMap seriesMap (NOLOCK) ON playerSeriesMap.SeriesMapID = seriesMap.SeriesMapID
                JOIN tblSeries series (NOLOCK) ON series.SeriesID = seriesMap.SeriesID
                WHERE playerSeriesMap.SeriesMapID = @seriesMapID
                ORDER BY (CASE WHEN series.HomeTeamID = seasonTeam.SeasonTeamID THEN 1 ELSE 0 END), playerSeriesMap.Kills desc, playerSeriesMap.Deaths, playerSeriesMap.Damage desc", parameters)).ToList();
            }
        }
    }
}
