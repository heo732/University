using Newtonsoft.Json;

namespace MainTool.Models
{
    public abstract class ResultRepresentation
    {
        [JsonIgnore]
        public abstract double AsDouble { get; }

        [JsonIgnore]
        public abstract string AsShortString { get; }

        [JsonIgnore]
        public string AsFullString => $"{AsDouble}: {AsShortString}";
    }
}