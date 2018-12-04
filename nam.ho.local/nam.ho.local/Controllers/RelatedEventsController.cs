using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nam.ho.local.Business;

namespace nam.ho.local.Controllers
{
    public class RelatedEventsController : Controller
    {
        private readonly RelatedEventsProvider _provider;

        public RelatedEventsController() : this(new RelatedEventsProvider())
        {
            
        }

        public RelatedEventsController(RelatedEventsProvider provider)
        {
            _provider = provider;
        }
        // GET: RelatedEvents
        public ActionResult Index()
        {
            return View(_provider.GetRelatedEvents());
        }
    }
}