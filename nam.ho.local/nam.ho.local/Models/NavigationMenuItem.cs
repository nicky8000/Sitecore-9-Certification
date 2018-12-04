using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nam.ho.local.Models
{
    public class NavigationMenuItem : NavigationItem
    {
        public NavigationMenuItem(string title, string url, IEnumerable<NavigationMenuItem> children) : base(title, url, false)
        {
            Children = children ?? new List<NavigationMenuItem>();
        }

        public IEnumerable<NavigationMenuItem> Children { get; private set; }
    }
}