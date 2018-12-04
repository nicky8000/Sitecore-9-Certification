using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nam.ho.local.Models;
using TAC.Sitecore.Abstractions.Interfaces;
using TAC.Sitecore.Abstractions.SitecoreImplementation;

namespace nam.ho.local.Business
{
    public class RelatedEventsProvider
    {
        private readonly IRenderingContext _context;

        public RelatedEventsProvider() : this(SitecoreRenderingContext.Create())
        {
        }

        public RelatedEventsProvider(IRenderingContext context)
        {
            _context = context;
        }

        public IEnumerable<NavigationItem> GetRelatedEvents()
        {
            return _context.ContextItem.GetMultilistFieldItems("RelatedEvents")
                .Select(x => new NavigationItem(x.DisplayName, x.Url, false));
        }
    }
}