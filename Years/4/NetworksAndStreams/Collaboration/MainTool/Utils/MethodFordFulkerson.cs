using MainTool.Exceptions;
using MainTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MainTool.Utils
{
    public static class MethodFordFulkerson
    {
        public static IEnumerable<GraphConnection> GetMinimumNetworkSection(int source, int target, IEnumerable<GraphConnection> graph)
        {
            if (!graph.Any())
            {
                return new List<GraphConnection>();
            }

            if (ThereIsNoWayFromSourceToTarget(source, target, graph))
            {
                throw new FlowImpossibleException("Неможливо знайти мінімальний переріз на мережі");
            }

            List<GraphConnection> flow = graph.Select(c => new GraphConnection(c.Source, c.Target, 0)).ToList();
            IEnumerable<GraphConnection> section = MakeIteration(source, target, graph, flow);

            while (section == null)
            {
                section = MakeIteration(source, target, graph, flow);
            }

            return section;
        }

        private static bool ThereIsNoWayFromSourceToTarget(int source, int target, IEnumerable<GraphConnection> graph)
        {
            var drainage = new List<GraphConnection>(graph.Where(c => c.Source == source));
            var reached = new List<GraphConnection>();

            while (drainage.Any())
            {
                var item = drainage.First();

                if (item.Target == target)
                {
                    return false;
                }

                drainage.AddRange(graph.Where(c => c.Source == item.Target && reached.All(r => r.Source != c.Source || r.Target != c.Target)));
                drainage.Remove(item);
                reached.Add(item);
            }

            return true;
        }

        private static IEnumerable<GraphConnection> MakeIteration(int source, int target, IEnumerable<GraphConnection> graph, List<GraphConnection> flow)
        {
            var N = new Dictionary<int, int> { { source, 0 } };
            var teta = new Dictionary<int, double> { { source, double.MaxValue } };
            var markedVertices = new HashSet<int> { source };

            while (true)
            {
                IEnumerable<int> unmarkedVertices = graph
                    .SelectMany(c => new GraphConnection[] { c.GetOrderedAscending(), c.GetOrderedDescending() })
                    .Select(c => c.Source)
                    .Distinct()
                    .Where(v => !markedVertices.Contains(v));

                // 1. J-
                var markedVertices_forward = new HashSet<int>();
                foreach (int unmarked in unmarkedVertices)
                {
                    IEnumerable<GraphConnection> from_marked_to_unmarked = markedVertices.SelectMany(marked => graph.Where(c => c.Source == marked && c.Target == unmarked));
                    foreach (GraphConnection connection in from_marked_to_unmarked)
                    {
                        if (connection.Value - flow.First(x => x.Source == connection.Source && x.Target == connection.Target).Value > 0)
                        {
                            markedVertices_forward.Add(unmarked);
                        }
                    }
                }
                
                // 2. J+
                var markedVertices_back = new HashSet<int>();
                foreach (int unmarked in unmarkedVertices.Where(v => !markedVertices_forward.Contains(v)))
                {
                    IEnumerable<GraphConnection> from_unmarked_to_marked = markedVertices.SelectMany(marked => graph.Where(c => c.Source == unmarked && c.Target == marked));
                    foreach (GraphConnection connection in from_unmarked_to_marked)
                    {
                        if (flow.First(x => x.Source == connection.Source && x.Target == connection.Target).Value > 0)
                        {
                            markedVertices_back.Add(unmarked);
                        }
                    }
                }

                // 3. Check Finish rule.
                if (!markedVertices_forward.Any() && !markedVertices_back.Any())
                {
                    return graph.Where(c => markedVertices.Contains(c.Source) && !markedVertices.Contains(c.Target));
                }

                // 4. Check target rule.
                if (!markedVertices_forward.Contains(target))
                {
                    // 5. Mark vertices.
                    foreach (int j in markedVertices_forward)
                    {
                        int i_node = markedVertices.Where(item => graph.Any(c => c.Source == item && c.Target == j && (graph.First(g => g.Source == c.Source && g.Target == c.Target).Value - flow.First(f => f.Source == c.Source && f.Target == c.Target).Value > 0))).OrderBy(item => item).First();

                        N.Add(j, i_node);

                        teta.Add(j, Math.Min(teta[i_node], graph.First(c => c.Source == i_node && c.Target == j).Value - flow.First(c => c.Source == i_node && c.Target == j).Value));
                    }

                    foreach (int k in markedVertices_back)
                    {
                        int i = markedVertices.Where(item => graph.Any(c => c.Source == k && c.Target == item && (flow.First(f => f.Source == c.Source && f.Target == c.Target).Value > 0))).OrderBy(item => item).First();

                        N.Add(k, -i);

                        teta.Add(k, Math.Min(teta[i], flow.First(c => c.Source == k && c.Target == i).Value));
                    }

                    foreach (int item in markedVertices_forward)
                    {
                        markedVertices.Add(item);
                    }

                    foreach (int item in markedVertices_back)
                    {
                        markedVertices.Add(item);
                    }

                    continue;
                }

                // 6. Mark target vertex.
                int i_target = markedVertices.Where(item => graph.Any(c => c.Source == item && c.Target == target && (graph.First(g => g.Source == c.Source && g.Target == c.Target).Value - flow.First(f => f.Source == c.Source && f.Target == c.Target).Value > 0))).OrderBy(item => item).First();
                N.Add(target, i_target);
                teta.Add(target, Math.Min(teta[i_target], graph.First(c => c.Source == i_target && c.Target == target).Value - flow.First(c => c.Source == i_target && c.Target == target).Value));

                // 7. Flow changing.
                GraphConnection i_t = flow.First(c => c.Source == i_target && c.Target == target);
                var newFlow = new List<GraphConnection> { new GraphConnection(i_t.Source, i_t.Target, i_t.Value + teta[target]) };

                bool sourceReached = i_target == source;
                int currentTarget = i_target;
                int currentSource = N[i_target];
                int currentSource_abs = Math.Abs(currentSource);
                while (!sourceReached)
                {
                    sourceReached = currentSource_abs == source;

                    if (currentSource > 0)
                    {
                        newFlow.Add(new GraphConnection(currentSource_abs, currentTarget, flow.First(c => c.Source == currentSource_abs && c.Target == currentTarget).Value + teta[target]));
                    }
                    else
                    {
                        newFlow.Add(new GraphConnection(currentTarget, currentSource_abs, flow.First(c => c.Source == currentTarget && c.Target == currentSource_abs).Value - teta[target]));
                    }

                    currentTarget = currentSource_abs;
                    currentSource = N[currentSource_abs];
                    currentSource_abs = Math.Abs(currentSource);
                }

                newFlow = newFlow.Concat(flow).Distinct(new GraphConnectionOrderedStartEndComparer()).ToList();
                flow.Clear();
                flow.AddRange(newFlow);
                return null;
            }
        }
    }
}