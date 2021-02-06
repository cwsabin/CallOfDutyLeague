using CallOfDutyLeague.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Controllers
{
    [Route("Series")]
    public class SeriesController : Controller
    {
        private ISeriesRepository seriesRepository;
        public SeriesController(ISeriesRepository seriesRepository)
        {
            this.seriesRepository = seriesRepository;
        }

        [Route("getSeriesScheduleByEvent/{eventID}")]
        public async Task<IActionResult> GetSeriesScheduleByEvent(long eventID)
        {
            return Json(await seriesRepository.GetSeriesScheduleByEventAsync(eventID));
        }
    }
}
