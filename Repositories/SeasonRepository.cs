using CallOfDutyLeague.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CallOfDutyLeague.Repositories
{
    public interface ISeasonRepository
    {
        public List<Season> GetAllSeasons();
    }

    public class SeasonRepository : ISeasonRepository
    {
        public List<Season> GetAllSeasons()
        {
            using (var con = new SqlConnection(Constants.ConnectionString))
            {
                return con.Query<Season>("SELECT SeasonID, Year FROM tblSeason (NOLOCK)").ToList();
            }
        }
    }
}
