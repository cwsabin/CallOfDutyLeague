using CallOfDutyLeague.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Controllers
{
    [Route("PlayerMap")]
    public class PlayerMapController : Controller
    {
        private IPlayerMapRepository playerMapRepository;

        public PlayerMapController(IPlayerMapRepository playerMapRepository)
        {
            this.playerMapRepository = playerMapRepository;
        }

        [Route("getPlayerStats/{seriesMapID}")]
        public async Task<IActionResult> GetPlayerStats(long seriesMapID)
        {
            return Json(await playerMapRepository.GetPlayerMapsAsync(seriesMapID));
        }
    }
}
