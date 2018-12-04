using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nam.ho.local.Models;
using TAC.Sitecore.Abstractions.Interfaces;
using TAC.Sitecore.Abstractions.SitecoreImplementation;

namespace nam.ho.local.Business
{
    public class NavigationBuilder
    {
        private readonly IRenderingContext _context;

        public NavigationBuilder() : this(SitecoreRenderingContext.Create())
        {
        }

        public NavigationBuilder(IRenderingContext context)
        {
            _context = context;
        }

        public NavigationMenuItem Build()
        {
            var root = _context.DatasourceOrContextItem;

            return new NavigationMenuItem(root?.DisplayName, root?.Url, 
                root != null && _context?.ContextItem != null ? Build(root, _context.ContextItem) : null);
        }

        public IEnumerable<NavigationMenuItem> Build(IItem node, IItem current)
        {
            return node.GetChildren().Select(x =>
                new NavigationMenuItem(x.DisplayName, x.Url, x.IsAncestorOrSelf(current) ? Build(x, current) : null));
        }
    }
}