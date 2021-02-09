using CallOfDutyLeague.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Controllers
{
    [Route("Team")]
    public class TeamController : Controller
    {
        private ITeamRepository teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("teams/{seasonTeamID}")]
        public async Task<IActionResult> Teams(int seasonTeamID)
        {
            return Json(await teamRepository.GetTeamBySeasonTeamIDAsync(seasonTeamID));
        }
    }
}
