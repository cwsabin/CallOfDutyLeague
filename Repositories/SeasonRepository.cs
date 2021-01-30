using CallOfDutyLeague.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Repositories
{
    public interface ISeasonRepository
    {
        public List<Season> GetAllSeasons();
        public Task<Season> GetCurrentSeasonAsync(DateTime date);
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

        public async Task<Season> GetCurrentSeasonAsync(DateTime date)
        {
            using (var con = new SqlConnection(Constants.ConnectionString))
            {
                var parameters = new { year = date.Year };
                return await con.QueryFirstAsync<Season>("Select SeasonID, Year FROM tblSeason (NOLOCK) WHERE Year = @year", parameters);
            }
        }
    }
}
