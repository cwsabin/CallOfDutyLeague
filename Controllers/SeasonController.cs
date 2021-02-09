using CallOfDutyLeague.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Controllers
{
    [Route("Season")]
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

        [Route("getCurrentSeason")]
        public async Task<IActionResult> GetCurrentSeason()
        {
            var currentSeason = await seasonRepository.GetCurrentSeasonAsync(DateTime.Today);
            return Json(currentSeason);
        }
    }
}
