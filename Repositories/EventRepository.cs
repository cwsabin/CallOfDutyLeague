using CallOfDutyLeague.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Repositories
{
    public interface IEventRepository
    {
        public Task<List<Event>> GetEvents();
    }
    public class EventRepository : IEventRepository
    {
        public async Task<List<Event>> GetEvents()
        {
            using (var con = new SqlConnection(Constants.ConnectionString))
            {
                return (await con.QueryAsync<Event>($@"SELECT event.EventID, event.EventName, event.StartDate, event.EndDate FROM tblEvent event (NOLOCK)")).ToList();
            }
        }
    }
}
