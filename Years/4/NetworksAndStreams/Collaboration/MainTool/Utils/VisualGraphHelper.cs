using System.Collections.Generic;
using System.Linq;

using GraphX.Controls;
using GraphX.PCL.Common.Enums;
using GraphX.PCL.Common.Models;
using GraphX.PCL.Logic.Models;

using QuickGraph;

using MainTool.Models;

namespace MainTool.Utils
{
    public static class VisualGraphHelper
    {
        public static void DrawGraph(VisualGraphArea area, IEnumerable<GraphConnection> logicalGraph, bool isDirectedEdges)
        {
            var visualGraph = new VisualGraph();
            Dictionary<int, VisualGraphVertex> vertexId_to_visualVertex = logicalGraph.ToUniqueIds().ToDictionary(id => id, id => new VisualGraphVertex(id.ToString()));

            foreach (VisualGraphVertex vertex in vertexId_to_visualVertex.Values)
            {
                visualGraph.AddVertex(vertex);
            }

            foreach (GraphConnection graphConnection in logicalGraph)
            {
                visualGraph.AddEdge(new VisualGraphEdge(vertexId_to_visualVertex[graphConnection.Source], vertexId_to_visualVertex[graphConnection.Target], graphConnection.Value));
                if (!isDirectedEdges)
                {
                    visualGraph.AddEdge(new VisualGraphEdge(vertexId_to_visualVertex[graphConnection.Target], vertexId_to_visualVertex[graphConnection.Source], graphConnection.Value));
                }
            }

            area.LogicCore = new VisualGraphLogicCore()
            {
                Graph = visualGraph,
                DefaultLayoutAlgorithm = LayoutAlgorithmTypeEnum.KK,
                DefaultOverlapRemovalAlgorithm = OverlapRemovalAlgorithmTypeEnum.FSA,
                DefaultEdgeRoutingAlgorithm = EdgeRoutingAlgorithmTypeEnum.SimpleER,
                AsyncAlgorithmCompute = false
            };

            area.LogicCore.DefaultOverlapRemovalAlgorithmParams.HorizontalGap = 150;
            area.LogicCore.DefaultOverlapRemovalAlgorithmParams.VerticalGap = 150;

            area.GenerateGraph();
            area.ShowAllEdgesLabels();
        }
    }

    public class VisualGraphVertex : VertexBase
    {
        public VisualGraphVertex(string text)
        {
            Text = text;
        }

        public string Text { get; }

        public override string ToString()
        {
            return Text;
        }
    }

    public class VisualGraphEdge : EdgeBase<VisualGraphVertex>
    {
        public VisualGraphEdge(VisualGraphVertex source, VisualGraphVertex target, double weight)
            : base(source, target, weight)
        {
        }

        public override string ToString()
        {
            return new string('\n', 1) + new string(' ', 5) + Weight.ToString();
        }
    }

    public class VisualGraph : BidirectionalGraph<VisualGraphVertex, VisualGraphEdge>
    {
    }

    public class VisualGraphArea : GraphArea<VisualGraphVertex, VisualGraphEdge, BidirectionalGraph<VisualGraphVertex, VisualGraphEdge>>
    {
    }

    public class VisualGraphLogicCore : GXLogicCore<VisualGraphVertex, VisualGraphEdge, BidirectionalGraph<VisualGraphVertex, VisualGraphEdge>>
    {
    }
}