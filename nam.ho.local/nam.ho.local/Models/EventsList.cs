using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nam.ho.local.Models
{
    public class EventsList
    {
        public EventsList(IEnumerable<EventDetails> events, int totalResultCount, int pageSize)
        {
            Events = events;
            TotalResultCount = totalResultCount;
            PageSize = pageSize;
        }

        public IEnumerable<EventDetails> Events { get; private set; }
        public int TotalResultCount { get; private set; }
        public int PageSize { get; private set; }
    }
}