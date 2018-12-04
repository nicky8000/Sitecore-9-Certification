using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nam.ho.local.Business;

namespace nam.ho.local.Controllers
{
    public class EventsListController : Controller
    {
        private readonly EventsProvider _provider;

        public EventsListController() : this(new EventsProvider())
        {
        }

        public EventsListController(EventsProvider provider)
        {
            _provider = provider;
        }

        // GET: EventsList
        public ActionResult Index(int page = 1)
        {
            var result = _provider.GetEventsList(page - 1);
            return View(result);
        }
    }
}