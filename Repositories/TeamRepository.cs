using CallOfDutyLeague.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CallOfDutyLeague.Repositories
{
    public interface ITeamRepository
    {
        public List<Team> GetTeamsBySeason(long seasonID);
    }

    public class TeamRepository : ITeamRepository
    {
        public List<Team> GetTeamsBySeason(long seasonID)
        {
            using (var conn = new SqlConnection(Constants.ConnectionString))
            {
                var parameters = new { SeasonID = seasonID };
                return conn.Query<Team>(@"SELECT team.TeamID, team.TeamName FROM tblTeam team (NOLOCK) WHERE EXISTS (SELECT 1 FROM tblSeasonTeam seasonTeam (NOLOCK) WHERE seasonTeam.SeasonID = @SeasonID AND seasonTeam.TeamID = team.TeamID)", parameters)
                    .ToList();
            }
        }
    }
}
