using System.Collections.Generic;

using MainTool.Models;

namespace MainTool.Utils
{
    public class GraphConnectionIgnoreOrderStartEndComparer : IEqualityComparer<GraphConnection>
    {
        public bool Equals(GraphConnection x, GraphConnection y)
        {
            GraphConnection x_ordered = x.GetOrderedAscending();
            GraphConnection y_ordered = y.GetOrderedAscending();
            return (x_ordered.Source == y_ordered.Source) && (x_ordered.Target == y_ordered.Target);
        }

        public int GetHashCode(GraphConnection obj)
        {
            return (obj.Source.GetHashCode(), obj.Target.GetHashCode()).GetHashCode();
        }
    }

    public class GraphConnectionOrderedStartEndComparer : IEqualityComparer<GraphConnection>
    {
        public bool Equals(GraphConnection x, GraphConnection y)
        {
            return (x.Source == y.Source) && (x.Target == y.Target);
        }

        public int GetHashCode(GraphConnection obj)
        {
            return (obj.Source.GetHashCode(), obj.Target.GetHashCode()).GetHashCode();
        }
    }
}