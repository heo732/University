using Newtonsoft.Json;
using System;

namespace MainTool.Models
{
    public class GraphConnection : ResultRepresentation
    {
        public GraphConnection(int source, int target, double value)
        {
            if ((source < 0) || (target < 0))
            {
                throw new ArgumentException("Від'ємний номер вершини!");
            }

            Source = source;
            Target = target;
            Value = value;
        }

        public int Source { get; private set; } = -1;

        public int Target { get; private set; } = -1;

        public double Value { get; private set; } = -1;

        public override double AsDouble => Value;

        public override string AsShortString => $"{Source}-{Target}";

        [JsonIgnore]
        public string AsPlainString => $"{Source} {Target} {Value}";

        public GraphConnection GetOrderedAscending()
        {
            int start = Math.Min(Source, Target);
            int end = Math.Max(Source, Target);
            return new GraphConnection(start, end, Value);
        }

        public GraphConnection GetOrderedDescending()
        {
            int start = Math.Max(Source, Target);
            int end = Math.Min(Source, Target);
            return new GraphConnection(start, end, Value);
        }
    }
}