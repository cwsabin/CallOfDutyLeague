using CallOfDutyLeague.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CallOfDutyLeague.Controllers
{
    public class SeasonController : Controller
    {
        private ISeasonRepository seasonRepository;
        
        public SeasonController(ISeasonRepository seasonRepository)
        {
            this.seasonRepository = seasonRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("seasons")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Seasons()
        {
            return Json(seasonRepository.GetAllSeasons());
        }
    }
}
