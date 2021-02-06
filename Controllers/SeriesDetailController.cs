using CallOfDutyLeague.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Controllers
{
    [Route("SeriesDetail")]
    public class SeriesDetailController : Controller
    {
        private ISeriesDetailRepository seriesDetailRepository;

        public SeriesDetailController(ISeriesDetailRepository seriesDetailRepository)
        {
            this.seriesDetailRepository = seriesDetailRepository;
        }

        [Route("getSeriesDetails/{seriesID}")]
        public async Task<IActionResult> GetSeriesDetails(long seriesID)
        {
            return Json(await seriesDetailRepository.GetSeriesDetails(seriesID));
        }
    }
}
