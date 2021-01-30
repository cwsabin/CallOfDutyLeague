using CallOfDutyLeague.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CallOfDutyLeague.Controllers
{
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

        [Route("teams/{id}")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Seasons(int id)
        {
            return Json(teamRepository.GetTeamsBySeason(id));
        }
    }
}
