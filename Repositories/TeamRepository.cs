using CallOfDutyLeague.Models;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Repositories
{
    public interface ITeamRepository
    {
        public Task<Team> GetTeamBySeasonTeamIDAsync(long seasonTeamID);
    }

    public class TeamRepository : ITeamRepository
    {
        public async Task<Team> GetTeamBySeasonTeamIDAsync(long seasonTeamID)
        {
            using (var conn = new SqlConnection(Constants.ConnectionString))
            {
                var parameters = new { SeasonTeamID = seasonTeamID };
                return (await conn.QueryFirstAsync<Team>(@"SELECT
	                        team.TeamID,
	                        team.TeamName
                        FROM tblTeam team (NOLOCK)
                        JOIN tblSeasonTeam seasonTeam (NOLOCK) ON seasonTeam.TeamID = team.TeamID
                        WHERE seasonTeam.SeasonTeamID = @SeasonTeamID", parameters));
            }
        }
    }
}
