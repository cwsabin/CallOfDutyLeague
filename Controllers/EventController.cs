using CallOfDutyLeague.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CallOfDutyLeague.Controllers
{
    public class EventController : Controller
    {
        private IEventRepository eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        [Route("getEvents")]
        public async Task<IActionResult> GetEvents()
        {
            return Json(await eventRepository.GetEvents());
        }
    }
}
