using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nam.ho.local.Models;
using TAC.Sitecore.Abstractions.Interfaces;
using TAC.Sitecore.Abstractions.SitecoreImplementation;

namespace nam.ho.local.Business
{
    public class BreadcrumbBuilder
    {
        private readonly IRenderingContext _context;
        public BreadcrumbBuilder() : this(SitecoreRenderingContext.Create())
        {
        }

        public BreadcrumbBuilder(IRenderingContext context)
        {
            _context = context;
        }

        public IEnumerable<NavigationItem> Build()
        {
            return _context?.HomeItem == null || _context?.ContextItem == null
                ? Enumerable.Empty<NavigationItem>()
                : _context.ContextItem.GetAncestors().Where(x => _context.HomeItem.IsAncestorOrSelf(x))
                    .Select(x => new NavigationItem(x.DisplayName, x.Url, false)).Concat(new[]
                        {new NavigationItem(_context.ContextItem.DisplayName, _context.ContextItem.Url, true)});
        }
    }
}