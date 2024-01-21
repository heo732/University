using Newtonsoft.Json;

using System.Collections.Generic;
using System.Linq;

namespace MainTool.Models
{
    public class WayRepresentation : ResultRepresentation
    {
        public WayRepresentation(IList<GraphConnection> way)
        {
            Way = way?.ToList() ?? new List<GraphConnection>();
        }

        public IReadOnlyList<GraphConnection> Way { get; private set; } = new List<GraphConnection>();

        public override string AsShortString
        {
            get
            {
                if (IsValidWay)
                {
                    return string.Join("-", Way.Select(connection => connection.Source).Concat(new int[] { Way.Last().Target }));
                }
                return string.Empty;
            }
        }

        public override double AsDouble
        {
            get
            {
                if (IsValidWay)
                {
                    return Way.Sum(connection => connection.Value);
                }
                return -1;
            }
        }

        [JsonIgnore]
        public bool IsValidWay
        {
            get
            {
                if ((Way == null) || (Way.Count < 1))
                {
                    return false;
                }

                int lastEnd = Way[0].Source;
                foreach (GraphConnection connection in Way)
                {
                    if (connection.Source != lastEnd)
                    {
                        return false;
                    }
                    lastEnd = connection.Target;
                }

                return true;
            }
        }
    }
}