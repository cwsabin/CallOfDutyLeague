using CallOfDutyLeague.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Controllers
{
    [Route("TeamRoster")]
    public class TeamRosterController : Controller
    {
        private ITeamRosterRepository teamRosterRepository;
        
        public TeamRosterController(ITeamRosterRepository teamRosterRepository)
        {
            this.teamRosterRepository = teamRosterRepository;
        }

        [Route("getRoster/{seasonTeamID}")]
        public async Task<IActionResult> GetRoster(long seasonTeamID)
        {
            return Json(await teamRosterRepository.GetRosterBySeasonTeamIDAsync(seasonTeamID));
        }
    }
}
