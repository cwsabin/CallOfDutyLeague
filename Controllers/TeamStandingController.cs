using CallOfDutyLeague.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CallOfDutyLeague.Controllers
{
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
    }
}
