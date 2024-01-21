using System.Collections.Generic;
using System.Linq;

using MainTool.Models;

namespace MainTool.Utils
{
    public static class CustomExtensions
    {
        public static HashSet<int> ToUniqueIds(this IEnumerable<GraphConnection> graph)
        {
            return new HashSet<int>(graph
                .SelectMany(c => new GraphConnection[] { c.GetOrderedAscending(), c.GetOrderedDescending() })
                .OrderBy(c => c.Source)
                .Select(c => c.Source));
        }

        public static string ToInlineString(this IEnumerable<WayRepresentation> ways)
        {
            return string.Join(";", ways.Select(way => way.AsFullString));
        }
    }
}