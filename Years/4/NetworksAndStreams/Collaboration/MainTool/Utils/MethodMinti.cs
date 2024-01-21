using System.Collections.Generic;
using System.Linq;

using MainTool.Models;

namespace MainTool.Utils
{
    public static class MethodMinti
    {
        public static IEnumerable<WayRepresentation> GetAllShortestWays(int initialNode, IEnumerable<GraphConnection> graph)
        {
            var graph_of_uniqueConnections = new HashSet<GraphConnection>((graph ?? new GraphConnection[0]).Distinct(new GraphConnectionIgnoreOrderStartEndComparer()));

            if (!graph_of_uniqueConnections.Any())
            {
                return new List<WayRepresentation>();
            }

            var allWays = new List<WayRepresentation>();
            BuildWaysFromTheNode(initialNode, new WayRepresentation(new GraphConnection[] { new GraphConnection(initialNode, initialNode, 0) }), graph_of_uniqueConnections, ref allWays);

            var shortest_wayStartEnd_toWayRep = new Dictionary<GraphConnection, WayRepresentation>(new GraphConnectionIgnoreOrderStartEndComparer());
            foreach (WayRepresentation wayRep in allWays)
            {
                var wayTotalData = new GraphConnection(wayRep.Way.First().Source, wayRep.Way.Last().Target, wayRep.AsDouble);
                if (shortest_wayStartEnd_toWayRep.TryGetValue(wayTotalData, out WayRepresentation wayRep_lastMinimalWeight))
                {
                    if (wayTotalData.Value < wayRep_lastMinimalWeight.AsDouble)
                    {
                        shortest_wayStartEnd_toWayRep[wayTotalData] = wayRep;
                    }
                }
                else
                {
                    shortest_wayStartEnd_toWayRep.Add(wayTotalData, wayRep);
                }
            }

            return shortest_wayStartEnd_toWayRep
                .Values
                .Select(wayRep => new WayRepresentation(wayRep.Way.Skip(2).ToList()))
                .OrderBy(wayRep => wayRep.AsFullString)
                .Where(wayRep => wayRep.Way.Any());
        }

        private static void BuildWaysFromTheNode(int node, WayRepresentation savedWayBeforeThisNode, HashSet<GraphConnection> graph, ref List<WayRepresentation> allWays)
        {
            int end = node;
            int start = savedWayBeforeThisNode.Way.Last().Target;
            var comparer = new GraphConnectionIgnoreOrderStartEndComparer();
            var connectionToCompare = new GraphConnection(start, end, 0);
            double weight = graph.FirstOrDefault(c => comparer.Equals(c, connectionToCompare))?.Value ?? 0;

            var wayToThisNode = new WayRepresentation(savedWayBeforeThisNode.Way.Concat(new GraphConnection[] { new GraphConnection(start, end, weight) }).ToList());
            allWays.Add(wayToThisNode);

            foreach (int nodeToGo in graph
                .Where(c => c.Source == node)
                .Select(c => c.Target)
                .Concat(graph
                    .Where(c => c.Target == node)
                    .Select(c => c.Source))
                .Where(nodeToGo => !savedWayBeforeThisNode.Way.ToUniqueIds().Contains(nodeToGo)))
            {
                BuildWaysFromTheNode(nodeToGo, wayToThisNode, graph, ref allWays);
            }
        }
    }
}