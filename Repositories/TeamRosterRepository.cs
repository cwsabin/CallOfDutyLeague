using CallOfDutyLeague.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Repositories
{
    public interface ITeamRosterRepository
    {
        public Task<List<TeamRoster>> GetRosterBySeasonTeamIDAsync(long seasonTeamID);
    }

    public class TeamRosterRepository : ITeamRosterRepository
    {
        public async Task<List<TeamRoster>> GetRosterBySeasonTeamIDAsync(long seasonTeamID)
        {
            using (var con = new SqlConnection(Constants.ConnectionString))
            {
                var parameters = new { seasonTeamID };
                return (await con.QueryAsync<TeamRoster>($@"SELECT
                            player.PlayerID,
                            playerTeam.SeasonTeamID,
                            player.GamerName,
                            player.FirstName,
                            player.LastName
                        FROM tblPlayerSeasonTeam playerTeam(NOLOCK)
                        JOIN tblPlayer player(NOLOCK) ON player.PlayerID = playerTeam.PlayerID
                        WHERE playerTeam.SeasonTeamID = @seasonTeamID AND playerTeam.IsActive = 1
                        ORDER BY player.GamerName", parameters)).ToList();
            }
        }
    }
}
