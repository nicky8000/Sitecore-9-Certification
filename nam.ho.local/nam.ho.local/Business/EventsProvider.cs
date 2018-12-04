using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nam.ho.local.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.Mvc.Presentation;

namespace nam.ho.local.Business
{
    public class EventsProvider
    {
        private const int PageSize = 4;

        public EventsList GetEventsList(int pageNo)
        {
            var indexName = $"events_{RenderingContext.Current.ContextItem.Database.Name.ToLower()}_index";
            var index = ContentSearchManager.GetIndex(indexName);
            using (var context = index.CreateSearchContext())
            {
                var result = context.GetQueryable<EventDetails>()
                    .Where(x => x.Paths.Contains(RenderingContext.Current.ContextItem.ID))
                    .Where(x => x.Language == RenderingContext.Current.ContextItem.Language.Name)
                    .Page(pageNo, PageSize)
                    .GetResults();
                return new EventsList(result.Hits.Select(x => x.Document).ToArray(), PageSize, result.TotalSearchResults);
            }
        }
    }
}