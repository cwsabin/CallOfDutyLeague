using CallOfDutyLeague.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Controllers
{
    [Route("TeamStandings")]
    public class TeamStandingController : Controller
    {
        private ITeamStandingRepository teamStandingRepository;

        public TeamStandingController(ITeamStandingRepository teamStandingRepository)
        {
            this.teamStandingRepository = teamStandingRepository;
        }

        [Route("getCurrentStandings/{year}")]
        public IActionResult GetCurrentStandings(short year)
        {
            return Json(teamStandingRepository.GetCurrentStandings(year));
        }

        [Route("getGroupStandings")]
        public async Task<IActionResult> GetGroupStandings()
        {
            return Json(await teamStandingRepository.GetGroupStandingsAsync());
        }
    }
}
